namespace OfaSchlupfer.MSSQLReflection {
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Elementary.Immutable;
    using OfaSchlupfer.MSSQLReflection.Model;
    using OfaSchlupfer.MSSQLReflection.Model.SqlSys;

    public sealed class Utility {
        private SqlSysUtiltiy _SysDatabase;

        private ModelSqlDatabase _ModelDatabase;

        public Utility() {
        }

        public string ConnectionString { get; set; }

        public SqlSysUtiltiy SysUtiltiy { get => this._SysDatabase; set => this._SysDatabase = value; }

        public ModelSqlDatabase ModelDatabase { get => this._ModelDatabase; set => this._ModelDatabase = value; }


        public SqlSysUtiltiy GetSource() {
            if (this.SysUtiltiy == null) {
                this.SysUtiltiy = new SqlSysUtiltiy() { TransConnection = new SqlTransConnection(this.ConnectionString) };
            }
            return this.SysUtiltiy;
        }

        public ModelSqlDatabase GetTarget() {
            if (this.ModelDatabase == null) {
                this.ModelDatabase = new ModelSqlDatabase();
            }
            return this.ModelDatabase;
        }

        public void ReadAll() {
            var sysDatabase = this.GetSource().ReadAllFromDatbase(null);
            this.ConvertSysToModel(sysDatabase, null);
        }

        public void ConvertSysToModel(SqlSysDatabase sysDatabase, ModelSqlDatabase targetDatabase) {
            if (sysDatabase == null) {
                var source = this.GetSource();
                sysDatabase = source.CurrentDatabase;
            }
            if (targetDatabase == null) {
                targetDatabase = this.GetTarget();
            }
            targetDatabase.Freeze();
            //
            var targetDatabasePair = targetDatabase.FactoryModelBuilderPair(
                (m, clone, setU, setF) => m.GetBuilder(clone, setU, setF),
                (builder, model) => {
                    // System.Diagnostics.Debug.WriteLine("unfreeze");
                    targetDatabase = model;
                },
                (builder, model) => {
                    // System.Diagnostics.Debug.WriteLine("freeze");
                    targetDatabase = model;
                }
                );

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

            //

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

            //
            using (var targetTablesPair = targetDatabasePair.FactoryModelBuilderProperty(
                    (owner) => owner.Tables,
                    (ownerBuilder, tables) => { ownerBuilder.Tables = tables; },
                    (model, clone, setU, setF) => model.GetBuilder(clone, setU, setF)
                )) {
                var targetTablesBuilder = targetTablesPair.Builder;
                foreach (var srcTable in sysDatabase.GetTables()) {
                    ModelSqlSchema modelSqlSchema;
                    if (schemaById.TryGetValue(srcTable.schema_id, out modelSqlSchema)) {
                        var tableName = modelSqlSchema.Name.Child(srcTable.name);
                        var foundTable = (ModelSqlTable)targetTablesBuilder.GetByName(tableName);
                        var dstTable = new ModelSqlTable();
                        dstTable.Name = tableName;
                        //
                        var dstTableBuilder = dstTable.GetBuilder(false, t => { dstTable = t; }, null);
                        {
                            var dstTableColumns = dstTable.Columns;
                            var dstTableColumnsBuilder = dstTableColumns.GetBuilder(false, c => { dstTableColumns = c; }, null);
                            //
                            foreach (var srcColumn in srcTable.Columns) {
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
                                    dstTableColumnsBuilder.Add(dstColumn.Name, dstColumn);
                                } else if (foundColumn != dstColumn) {
                                    dstTableColumnsBuilder.Add(dstColumn.Name, dstColumn);
                                } else {
                                    dstColumn = foundColumn;
                                }
                            }
                            //
                            dstTableColumns = dstTableColumnsBuilder.GetTarget();
                            dstTableBuilder.Columns = dstTableColumns;
                        }
                        //
                        dstTable = dstTableBuilder.GetTarget();
                        if ((object)foundTable == null) {
                            dstTable.Freeze();
                            targetTablesBuilder.Add(dstTable.Name, dstTable);
                        } else if (foundTable == dstTable) {
                            dstTable.Freeze();
                            targetTablesBuilder.Add(dstTable.Name, dstTable);
                        } else {
                            dstTable = foundTable;
                        }
                        objectById[srcTable.object_id] = dstTable;
                    }
                }
                targetTablesBuilder.GetTarget();
            }

            //
            this.ModelDatabase = targetDatabasePair.Builder.GetTarget();
        }

        /*

                public void ConvertAndAddSqlSchema(SqlSchemaAccess src) {
                    var dst = new SqlSchema();
                    dst.Name = SqlName.Parse(src.name);
                    dst.SchemaID = src.schema_id;
                    this.Target.AddSchema(dst);
                }

                public void ConvertAndAddSqlTable(SqlTableAccess src) {
                    var schema = this.Target.GetSchemaById(src.schema_id);
                    var dst = new SqlTable();
                    dst.ObjectId = src.object_id;
                    dst.Name = schema.Name.Child(src.name);
                    this.Target.AddTable(dst);
                }

                public void ConvertAndAddSqlColumn(SqlColumnAccess src) {
                    var table = this.Target.GetObjectById(src.object_id) as SqlTable;
                    var dst = new SqlColumn();
                    dst.ColumnId = src.column_id;
                    dst.Name = table.Name.Child(src.name);
                    table.AddColumn(dst);
                }
                 */
    }
}
