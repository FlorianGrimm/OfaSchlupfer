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
            if (result is null) {
                result = new ModelSqlServer();
                if ((object)this.SysServer == null) {
                    result.Name = new SqlName(null, "default", ObjectLevel.Server);
                } else {
                    result.Name = new SqlName(null, this.SysServer.servername, ObjectLevel.Server);
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
                schemaById[src.schema_id] = ModelSqlSchema.Ensure(targetDatabase, src.name);
            }

            #region types
            {
                foreach (var srcType in sysDatabase.Types) {
                    if (schemaById.TryGetValue(srcType.schema_id, out var modelSqlSchema)) {
                        ModelSqlType dstType = ModelSqlType.Ensure(modelSqlSchema, srcType.name);
                        dstType.MaxLength = srcType.max_length;
                        dstType.Precision = srcType.precision;
                        dstType.Scale = srcType.scale;
                        dstType.CollationName = srcType.collation_name;
                        dstType.Nullable = srcType.is_nullable;

                        typeById[srcType.user_type_id] = dstType;
                        typeByName[dstType.Name] = dstType;
                    }
                }
            }
            #endregion types
            #region tabletypes
            {
                foreach (var srcTableType in sysDatabase.GetTableType()) {
                    if (schemaById.TryGetValue(srcTableType.schema_id, out var modelSqlSchema)) {
                        var dstTableType = ModelSqlTableType.Ensure(modelSqlSchema, srcTableType.name);

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
                        objectById[srcTableType.object_id] = dstTableType;
                    }
                }
            }
            #endregion tabletypes
            #region tables
            {
                foreach (var srcTable in sysDatabase.GetTables()) {
                    if (schemaById.TryGetValue(srcTable.schema_id, out var modelSqlSchema)) {
                        var dstTable = ModelSqlTable.Ensure(modelSqlSchema, srcTable.name);

                        // srcTable.Columns
                        var srcTable_Columns = srcTable.Columns;
                        if (srcTable_Columns != null) {
                            foreach (var srcColumn in srcTable_Columns) {
#warning
                                var dstColumn = ConvertSysToModelColumn(typeById, dstTable, srcColumn);
                                //var foundColumn = dstTable.GetColumnByName(dstColumn.Name);
                                //if ((foundColumn == null) || (foundColumn != dstColumn)) {
                                //    dstColumn.AddToParent();
                                //} else {
                                //    dstColumn = foundColumn;
                                //}
                            }
                        }

                        objectById[srcTable.object_id] = dstTable;
                    }
                }
            }
            #endregion tables
            #region view
            {
                foreach (var srcView in sysDatabase.GetViews()) {
                    if (schemaById.TryGetValue(srcView.schema_id, out var modelSqlSchema)) {
                        var dstView = ModelSqlView.Ensure(modelSqlSchema, srcView.name);

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

                        objectById[srcView.object_id] = dstView;
                    }
                }
            }
            #endregion view
            #region Synonyms
            {
                foreach (var srcSynonym in sysDatabase.GetSynonyms()) {
                    if (schemaById.TryGetValue(srcSynonym.schema_id, out var modelSqlSchema)) {
                        var dstSynonym = ModelSqlSynonym.Ensure(modelSqlSchema, srcSynonym.name);
                        objectById[srcSynonym.object_id] = dstSynonym;
                    }
                }
            }
            #endregion Synonyms
            #region StoredProdedures
            {
                foreach (var srcProcedure in sysDatabase.GetSqlStoredProcedures()) {
                    if (schemaById.TryGetValue(srcProcedure.schema_id, out var modelSqlSchema)) {
                        var dstProcedure = ModelSqlProcedure.Ensure(modelSqlSchema, srcProcedure.name);
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
            var dstColumn = ModelSqlColumn.Ensure(dstObjectWithColumns, srcColumn.name);
            dstColumn.ColumnId = srcColumn.column_id;
            ModelSqlType foundSqlType = typeById.GetValueOrDefault(srcColumn.user_type_id);
            var typeScalar = new ModelSqlType {
                BaseOnType = foundSqlType,
                MaxLength = srcColumn.max_length,
                Precision = srcColumn.precision,
                Scale = srcColumn.scale,
                CollationName = srcColumn.collation_name,
                Nullable = srcColumn.is_nullable
            };
            dstColumn.SqlType = foundSqlType;
            return dstColumn;
        }
    }
}
