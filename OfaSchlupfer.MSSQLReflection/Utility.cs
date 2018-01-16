namespace OfaSchlupfer.MSSQLReflection {
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Elementary.Immutable;
    using OfaSchlupfer.MSSQLReflection.Model;
    using OfaSchlupfer.MSSQLReflection.Model.SqlSys;

    /// <summary>
    /// Utility
    /// </summary>
    public sealed class Utility {
        private SqlSysUtiltiy _SysDatabase;

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
        /// Gets or sets the sql source.
        /// </summary>
        public SqlSysUtiltiy SysUtiltiy { get => this._SysDatabase; set => this._SysDatabase = value; }

        /// <summary>
        /// Gets or sets the target model
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

            // for testing?
            // targetDatabase.Freeze();

            // pair
            var targetDatabasePair = targetDatabase.FactoryModelBuilderPair(
                (model, clone, setU, setF) => model.GetBuilder(clone, setU, setF),
                (builder, model) => {
                    targetDatabase = model;
                },
                (builder, model) => {
                    targetDatabase = model;
                });

            var schemaById = new Dictionary<int, ModelSqlSchema>();
            var objectById = new Dictionary<int, object>();
            var typeByName = new Dictionary<SqlName, ModelSqlType>();
            var typeById = new Dictionary<int, ModelSqlType>();

            using (var targetSchemaPair = targetDatabasePair.FactoryModelBuilderProperty(
                    (owner) => owner.Schemas,
                    (ownerBuilder, schemas) => { ownerBuilder.Schemas = schemas; },
                    (schemas, clone, setU, setF) => schemas.GetBuilder(clone, setU, setF))) {
                var targetSchemaBuilder = targetSchemaPair.Builder;
                foreach (var src in sysDatabase.SchemaById.Values.ToArray()) {
                    var name = SqlName.Root.ChildWellkown(src.name);
                    ModelSqlSchema foundSchema = targetSchemaBuilder.GetByName(name);
                    var dstSchema = new ModelSqlSchema();
                    dstSchema.Name = name;
                    if ((object)foundSchema == null) {
                        dstSchema.Freeze();
                        targetSchemaBuilder.Add(dstSchema.Name, dstSchema);
                    } else if (foundSchema != dstSchema) {
                        dstSchema.Freeze();
                        targetSchemaBuilder.Add(dstSchema.Name, dstSchema);
                    } else {
                        dstSchema = foundSchema;
                    }
                    schemaById[src.schema_id] = dstSchema;
                }
                targetSchemaPair.GetTarget();
            }

            // add types
            using (var targetTypesPair = targetDatabasePair.FactoryModelBuilderProperty(
                    (db) => db.Types,
                    (dbBuilder, types) => { dbBuilder.Types = types; },
                    (types, clone, setU, setF) => types.GetBuilder(clone, setU, setF))) {
                var targetTypesBuilder = targetTypesPair.Builder;
                foreach (var srcType in sysDatabase.Types) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcType.schema_id, out modelSqlSchema)) {
                        var name = modelSqlSchema.Name.Child(srcType.name);
                        ModelSqlType foundType = targetTypesBuilder.GetByName(name);
                        ModelSqlType dstType = new ModelSqlType();
                        dstType.Name = name;
                        dstType.MaxLength = srcType.max_length;
                        dstType.Precision = srcType.precision;
                        dstType.Scale = srcType.scale;
                        dstType.CollationName = srcType.collation_name;
                        dstType.IsNullable = srcType.is_nullable;
                        if ((object)foundType == null) {
                            dstType.Freeze();
                            targetTypesBuilder.Add(dstType.Name, dstType);
                        } else if (foundType == dstType) {
                            dstType.Freeze();
                            targetTypesBuilder.Add(dstType.Name, dstType);
                        } else {
                            dstType = foundType;
                        }
                        typeById[srcType.user_type_id] = dstType;
                        typeByName[dstType.Name] = dstType;
                    }
                }
                targetTypesPair.GetTarget();
            }

            // add tables
            using (var targetTablesPair = targetDatabasePair.FactoryModelBuilderProperty(
                    (owner) => owner.Tables,
                    (ownerBuilder, tables) => { ownerBuilder.Tables = tables; },
                    (model, clone, setU, setF) => model.GetBuilder(clone, setU, setF))) {
                var targetTablesBuilder = targetTablesPair.Builder;
                foreach (var srcTable in sysDatabase.GetTables()) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcTable.schema_id, out modelSqlSchema)) {
                        var tableName = modelSqlSchema.Name.Child(srcTable.name);
                        var foundTable = (ModelSqlTable)targetTablesBuilder.GetByName(tableName);
                        var dstTable = new ModelSqlTable();
                        dstTable.Name = tableName;

                        // dstTable.FactoryModelBuilderPair2(_ => _.GetBuilder);
                        // targetTablesPair.

                        // tables
                        var dstTableBuilder = dstTable.GetBuilder(false, t => { dstTable = t; }, null);
                        {
                            using (var dstTableColumnsPair = dstTable.Columns.FactoryModelBuilderPair(
                                (model, clone, setU, setF) => model.GetBuilder(clone, setU, setF),
                                null,
                                (builder, model) => { dstTableBuilder.Columns = model; })) {
                                var dstTableColumnsBuilder = dstTableColumnsPair.Builder;

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
                                        dstColumn.Freeze();
                                        if (foundColumn == null) {
                                            dstTableColumnsBuilder.Add(dstColumn.Name, dstColumn);
                                        } else if (foundColumn != dstColumn) {
                                            dstTableColumnsBuilder.Add(dstColumn.Name, dstColumn);
                                        } else {
                                            dstColumn = foundColumn;
                                            dstTableColumnsBuilder.Add(dstColumn.Name, dstColumn);
                                        }
                                    }
                                }
                                dstTableColumnsPair.Freeze();
                            }
                        }

                        // store back
                        dstTable = dstTableBuilder.GetTarget();
                        if ((object)foundTable == null) {
                            targetTablesBuilder.Add(dstTable.Name, dstTable);
                        } else if (foundTable == dstTable) {
                            targetTablesBuilder.Add(dstTable.Name, dstTable);
                        } else {
                            dstTable = foundTable;
                        }
                        objectById[srcTable.object_id] = dstTable;
                    }
                }
                targetTablesBuilder.GetTarget();
            }

            // store back
            this.ModelDatabase = targetDatabasePair.Builder.GetTarget();
        }
    }
}
