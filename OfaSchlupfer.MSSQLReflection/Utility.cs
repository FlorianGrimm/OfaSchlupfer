#pragma warning disable SA1123 // Do not place regions within elements

namespace OfaSchlupfer.MSSQLReflection {
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.MSSQLReflection.Model;
    using OfaSchlupfer.MSSQLReflection.Model.SqlSys;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// Utility
    /// </summary>
    public sealed class Utility {
        private SqlSysUtiltiy _SysUtiltiy;
        private ModelSqlDatabase _ModelDatabase;

        /// <summary>
        /// Initializes a new instance of the <see cref="Utility"/> class.
        /// </summary>
        public Utility() {
        }

        /// <summary>
        /// Gets or sets the ConnectionString.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the source server SysServer.
        /// </summary>
        public SqlSysServer SysServer { get; set; }

        /// <summary>
        /// Gets or sets the target model for server.
        /// </summary>
        public ModelSqlServer ModelServer { get; set; }

        /// <summary>
        /// Gets or sets the sql source.
        /// </summary>
        public SqlSysUtiltiy SysUtiltiy { get => this._SysUtiltiy; set => this._SysUtiltiy = value; }

        /// <summary>
        /// Gets or sets the target model for the database
        /// </summary>
        public ModelSqlDatabase ModelDatabase { get => this._ModelDatabase; set => this._ModelDatabase = value; }

        /// <summary>
        /// GetModelServer
        /// </summary>
        /// <returns>the ModelServer.</returns>
        public ModelSqlServer GetModelServer() {
            var result = this.ModelServer;
            if ((object)result == null) {
                result = new ModelSqlServer();
                if ((object)this.SysServer == null) {
                    result.Name = SqlName.Root.ChildWellkown("default");
                } else {
                    result.Name = SqlName.Root.ChildWellkown(this.SysServer.servername);
                }
                this.ModelServer = result;
            }
            return result;
        }

        /// <summary>
        /// get the source - created if needed
        /// </summary>
        /// <returns>the exiting or new instance</returns>
        public SqlSysUtiltiy GetSource() {
            if (this.SysUtiltiy == null) {
                this.SysUtiltiy = new SqlSysUtiltiy() { TransConnection = new SqlTransConnection(this.ConnectionString) };
            }
            return this.SysUtiltiy;
        }

        /// <summary>
        /// get the target - created if needed
        /// </summary>
        /// <param name="name">the name of the db.</param>
        /// <returns>the exiting or new instance</returns>
        public ModelSqlDatabase GetTarget(string name) {
            if (this.ModelDatabase == null) {
                var server = this.GetModelServer();
                this.ModelDatabase = new ModelSqlDatabase(server, name);
                server.AddDatabase(this.ModelDatabase);
            }
            return this.ModelDatabase;
        }

        /// <summary>
        /// read meta from the sql db
        /// </summary>
        public void ReadAll() {
            var sysDatabase = this.GetSource().ReadAllFromDatabase(null);
            this.ConvertSysToModel(sysDatabase, null);
        }

        /// <summary>
        /// Convert the SqlSysDatabase to ModelSqlDatabase
        /// </summary>
        /// <param name="sysDatabase">the source.</param>
        /// <param name="targetDatabase">the target.</param>
        public void ConvertSysToModel(SqlSysDatabase sysDatabase, ModelSqlDatabase targetDatabase) {
            if ((object)sysDatabase == null) {
                var source = this.GetSource();
                sysDatabase = source.CurrentDatabase;
            }
            if (sysDatabase == null) { return; }
            if ((object)targetDatabase == null) {
                targetDatabase = this.GetTarget(sysDatabase.name);
            }
            if ((object)targetDatabase == null) { return; }

            var schemaById = new Dictionary<int, ModelSqlSchema>();
            var objectById = new Dictionary<int, object>();
            var typeByName = new Dictionary<SqlName, ModelSqlType>();
            var typeById = new Dictionary<int, ModelSqlType>();

            foreach (var src in sysDatabase.SchemaById.Values.ToArray()) {
                var dstSchema = new ModelSqlSchema(targetDatabase, src.name);
                ModelSqlSchema foundSchema = targetDatabase.Schemas.GetValueOrDefault(dstSchema.Name);
                if (((object)foundSchema == null) || (foundSchema != dstSchema)) {
                    dstSchema.AddToParent();
                } else {
                    dstSchema = foundSchema;
                }
                schemaById[src.schema_id] = dstSchema;
            }

            #region types
            {
                foreach (var srcType in sysDatabase.Types) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcType.schema_id, out modelSqlSchema)) {
                        ModelSqlType dstType = new ModelSqlType(modelSqlSchema, srcType.name);
                        ModelSqlType foundType = targetDatabase.Types.GetValueOrDefault(dstType.Name);
                        dstType.MaxLength = srcType.max_length;
                        dstType.Precision = srcType.precision;
                        dstType.Scale = srcType.scale;
                        dstType.CollationName = srcType.collation_name;
                        dstType.IsNullable = srcType.is_nullable;
                        if (((object)foundType == null) && (foundType != dstType)) {
                            dstType.AddToParent();
                        } else {
                            dstType = foundType;
                        }
                        typeById[srcType.user_type_id] = dstType;
                        typeByName[dstType.Name] = dstType;
                    }
                }
            }
            #endregion types
            #region tabletypes
            {
                foreach (var srcTableType in sysDatabase.GetTableType()) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcTableType.schema_id, out modelSqlSchema)) {
                        var dstTableType = new ModelSqlTableType(modelSqlSchema, srcTableType.name);
                        var foundTableType = targetDatabase.TableTypes.GetValueOrDefault(dstTableType.Name);

                        // srcTable.Columns
                        var srcTableType_Columns = srcTableType.Columns;
                        if (srcTableType_Columns != null) {
                            foreach (var srcColumn in srcTableType_Columns) {
                                var dstColumn = ConvertSysToModelColumn(typeById, dstTableType, srcColumn);
                                ModelSqlColumn foundColumn = dstTableType.GetColumnByName(dstColumn.Name);
                                if ((foundColumn == null) || (foundColumn != dstColumn)) {
                                    dstColumn.AddToParent();
                                } else {
                                    dstColumn = foundColumn;
                                }
                            }
                        }

                        // store back
                        if (((object)foundTableType == null) || (foundTableType != dstTableType)) {
                            dstTableType.AddToParent();
                        } else {
                            dstTableType = foundTableType;
                        }
                        objectById[srcTableType.object_id] = dstTableType;
                    }
                }
            }
            #endregion tabletypes
            #region tables
            {
                foreach (var srcTable in sysDatabase.GetTables()) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcTable.schema_id, out modelSqlSchema)) {
                        var dstTable = new ModelSqlTable(modelSqlSchema, srcTable.name);
                        var foundTable = targetDatabase.Tables.GetValueOrDefault(dstTable.Name);

                        // srcTable.Columns
                        var srcTable_Columns = srcTable.Columns;
                        if (srcTable_Columns != null) {
                            foreach (var srcColumn in srcTable_Columns) {
                                var dstColumn = ConvertSysToModelColumn(typeById, dstTable, srcColumn);
                                var foundColumn = dstTable.GetColumnByName(dstColumn.Name);
                                if ((foundColumn == null) || (foundColumn != dstColumn)) {
                                    dstColumn.AddToParent();
                                } else {
                                    dstColumn = foundColumn;
                                }
                            }
                        }

                        // store back
                        if (((object)foundTable == null) || (foundTable != dstTable)) {
                            dstTable.AddToParent();
                        } else {
                            dstTable = foundTable;
                        }
                        objectById[srcTable.object_id] = dstTable;
                    }
                }
            }
            #endregion tables
            #region view
            {
                foreach (var srcView in sysDatabase.GetViews()) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcView.schema_id, out modelSqlSchema)) {
                        var dstView = new ModelSqlView(modelSqlSchema, srcView.name);
                        var foundView = targetDatabase.Views.GetValueOrDefault(dstView.Name);

                        // srcTable.Columns
                        var srcTable_Columns = srcView.Columns;
                        if (srcTable_Columns != null) {
                            foreach (var srcColumn in srcTable_Columns) {
                                var dstColumn = ConvertSysToModelColumn(typeById, dstView, srcColumn);
                                var foundColumn = dstView.GetColumnByName(dstColumn.Name);
                                if ((foundColumn == null) || (foundColumn != dstColumn)) {
                                    dstColumn.AddToParent();
                                } else {
                                    dstColumn = foundColumn;
                                }
                            }
                        }

                        // store back
                        if (((object)foundView == null) || (foundView != dstView)) {
                            dstView.AddToParent();
                        } else {
                            dstView = foundView;
                        }
                        objectById[srcView.object_id] = dstView;
                    }
                }
            }
            #endregion view
            #region Synonyms
            {
                foreach (var srcSynonym in sysDatabase.GetSynonyms()) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcSynonym.schema_id, out modelSqlSchema)) {
                        var dstSynonym = new ModelSqlSynonym(modelSqlSchema, srcSynonym.name);
                        var foundSynonym = targetDatabase.Synonyms.GetValueOrDefault(dstSynonym.Name);

                        // store back
                        if (((object)foundSynonym == null) || (foundSynonym != dstSynonym)) {
                            dstSynonym.AddToParent();
                        } else {
                            dstSynonym = foundSynonym;
                        }
                        objectById[srcSynonym.object_id] = dstSynonym;
                    }
                }
            }
            #endregion Synonyms
            #region StoredProdedures
            {
                foreach (var srcProcedure in sysDatabase.GetSqlStoredProcedures()) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcProcedure.schema_id, out modelSqlSchema)) {
                        var dstProcedure = new ModelSqlProcedure(modelSqlSchema, srcProcedure.name);
                        var foundProcedure = targetDatabase.Procedures.GetValueOrDefault(dstProcedure.Name);

                        // store back
                        if (((object)foundProcedure == null) || (foundProcedure != dstProcedure)) {
                            dstProcedure.AddToParent();
                        } else {
                            dstProcedure = foundProcedure;
                        }
                        objectById[srcProcedure.object_id] = dstProcedure;
                    }
                }
            }
            #endregion StoredProdedures
        }

        private static ModelSqlColumn ConvertSysToModelColumn(
            Dictionary<int, ModelSqlType> typeById,
            IModelSqlObjectWithColumns dstObjectWithColumns,
            SqlSysColumn srcColumn) {
            var dstColumn = new ModelSqlColumn(dstObjectWithColumns, srcColumn.name);
            dstColumn.ColumnId = srcColumn.column_id;
            ModelSqlType foundSqlType = typeById.GetValueOrDefault(srcColumn.user_type_id);
            var typeScalar = new ModelSqlType();
            typeScalar.BaseOnType = foundSqlType;
            typeScalar.MaxLength = srcColumn.max_length;
            typeScalar.Precision = srcColumn.precision;
            typeScalar.Scale = srcColumn.scale;
            typeScalar.CollationName = srcColumn.collation_name;
            typeScalar.IsNullable = srcColumn.is_nullable;
            dstColumn.SqlType = foundSqlType;
            return dstColumn;
        }
    }
}
