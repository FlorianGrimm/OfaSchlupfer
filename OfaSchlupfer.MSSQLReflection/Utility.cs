namespace OfaSchlupfer.MSSQLReflection {
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.MSSQLReflection.Model;
    using OfaSchlupfer.MSSQLReflection.Model.SqlSys;

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
            var sysDatabase = this.GetSource().ReadAllFromDatbase(null);
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

            // add types
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

            foreach (var srcTable in sysDatabase.GetTables()) {
                ModelSqlSchema modelSqlSchema;
                if (schemaById.TryGetValue(srcTable.schema_id, out modelSqlSchema)) {
                    var dstTable = new ModelSqlTable(modelSqlSchema, srcTable.name);
                    var foundTable = targetDatabase.Tables.GetValueOrDefault(dstTable.Name);

                    // srcTable.Columns
                    var srcTable_Columns = srcTable.Columns;
                    if (srcTable_Columns != null) {
                        foreach (var srcColumn in srcTable_Columns) {
                            var dstColumn = new ModelSqlColumn(dstTable, srcColumn.name);
                            ModelSqlColumn foundColumn = dstTable.GetColumnByName(dstColumn.Name);
                            dstColumn.ColumnId = srcColumn.column_id;
                            dstColumn.MaxLength = srcColumn.max_length;
                            dstColumn.Precision = srcColumn.precision;
                            dstColumn.Scale = srcColumn.scale;
                            dstColumn.CollationName = srcColumn.collation_name;
                            dstColumn.IsNullable = srcColumn.is_nullable;
                            ModelSqlType foundSqlType = typeById.GetValueOrDefault(srcColumn.user_type_id);
                            dstColumn.SqlType = foundSqlType;
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

            foreach (var srcView in sysDatabase.GetViews()) {
                ModelSqlSchema modelSqlSchema;
                if (schemaById.TryGetValue(srcView.schema_id, out modelSqlSchema)) {
                    var dstView = new ModelSqlView(modelSqlSchema, srcView.name);
                    var foundView = targetDatabase.Views.GetValueOrDefault(dstView.Name);

                    // srcTable.Columns
                    var srcTable_Columns = srcView.Columns;
                    if (srcTable_Columns != null) {
                        foreach (var srcColumn in srcTable_Columns) {
                            var dstColumn = new ModelSqlColumn(dstView, srcColumn.name);
                            ModelSqlColumn foundColumn = dstView.GetColumnByName(dstColumn.Name);
                            dstColumn.ColumnId = srcColumn.column_id;
                            dstColumn.MaxLength = srcColumn.max_length;
                            dstColumn.Precision = srcColumn.precision;
                            dstColumn.Scale = srcColumn.scale;
                            dstColumn.CollationName = srcColumn.collation_name;
                            dstColumn.IsNullable = srcColumn.is_nullable;
                            ModelSqlType foundSqlType = typeById.GetValueOrDefault(srcColumn.user_type_id);
                            dstColumn.SqlType = foundSqlType;
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
    }
}
