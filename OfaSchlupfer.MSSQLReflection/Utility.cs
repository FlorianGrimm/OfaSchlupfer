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
        /// <returns>the exiting or new instance</returns>
        public ModelSqlDatabase GetTarget() {
            if (this.ModelDatabase == null) {
                this.ModelDatabase = new ModelSqlDatabase();
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
            if (sysDatabase == null) {
                var source = this.GetSource();
                sysDatabase = source.CurrentDatabase;
            }
            if (targetDatabase == null) {
                targetDatabase = this.GetTarget();
            }

            var schemaById = new Dictionary<int, ModelSqlSchema>();
            var objectById = new Dictionary<int, object>();
            var typeByName = new Dictionary<SqlName, ModelSqlType>();
            var typeById = new Dictionary<int, ModelSqlType>();

            foreach (var src in sysDatabase.SchemaById.Values.ToArray()) {
                var name = SqlName.Root.ChildWellkown(src.name);
                ModelSqlSchema foundSchema = targetDatabase.GetSchemaByName(name);
                var dstSchema = new ModelSqlSchema();
                dstSchema.Name = name;
                if ((object)foundSchema == null) {
                    targetDatabase.Schemas.Add(dstSchema.Name, dstSchema);
                } else if (foundSchema != dstSchema) {
                    targetDatabase.Schemas[dstSchema.Name] = dstSchema;
                } else {
                    dstSchema = foundSchema;
                }
                schemaById[src.schema_id] = dstSchema;
            }

            // add types
            foreach (var srcType in sysDatabase.Types) {
                ModelSqlSchema modelSqlSchema;
                if (schemaById.TryGetValue(srcType.schema_id, out modelSqlSchema)) {
                    var name = modelSqlSchema.Name.Child(srcType.name);
                    ModelSqlType foundType = targetDatabase.GetTypeByName(name);
                    ModelSqlType dstType = new ModelSqlType();
                    dstType.Name = name;
                    dstType.MaxLength = srcType.max_length;
                    dstType.Precision = srcType.precision;
                    dstType.Scale = srcType.scale;
                    dstType.CollationName = srcType.collation_name;
                    dstType.IsNullable = srcType.is_nullable;
                    if ((object)foundType == null) {
                        targetDatabase.Types.Add(dstType.Name, dstType);
                    } else if (foundType == dstType) {
                        targetDatabase.Types[dstType.Name] = dstType;
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
                    var tableName = modelSqlSchema.Name.Child(srcTable.name);
                    var foundTable = (ModelSqlTable)targetDatabase.GetTableByName(tableName);
                    var dstTable = new ModelSqlTable();
                    dstTable.Name = tableName;

                    // srcTable.Columns
                    var srcTable_Columns = srcTable.Columns;
                    if (srcTable_Columns != null) {
                        foreach (var srcColumn in srcTable_Columns) {
                            var columnName = tableName.ScopeChild(srcTable.name);
                            ModelSqlColumn foundColumn = dstTable.GetColumnByName(columnName);
                            var dstColumn = new ModelSqlColumn();
                            dstColumn.Name = columnName;
                            dstColumn.ColumnId = srcColumn.column_id;
                            dstColumn.MaxLength = srcColumn.max_length;
                            dstColumn.Precision = srcColumn.precision;
                            dstColumn.Scale = srcColumn.scale;
                            dstColumn.CollationName = srcColumn.collation_name;
                            dstColumn.IsNullable = srcColumn.is_nullable;
                            ModelSqlType foundSqlType = typeById.GetValueOrDefault(srcColumn.user_type_id);
                            dstColumn.SqlType = foundSqlType;
                            if (foundColumn == null) {
                                dstTable.Columns.Add(dstColumn.Name, dstColumn);
                            } else if (foundColumn != dstColumn) {
                                dstTable.Columns[dstColumn.Name] = dstColumn;
                            } else {
                                dstColumn = foundColumn;
                            }
                        }
                    }

                    // store back
                    if ((object)foundTable == null) {
                        targetDatabase.Tables.Add(dstTable.Name, dstTable);
                    } else if (foundTable == dstTable) {
                        targetDatabase.Tables[dstTable.Name] = dstTable;
                    } else {
                        dstTable = foundTable;
                    }
                    objectById[srcTable.object_id] = dstTable;
                }
            }
        }
    }
}
