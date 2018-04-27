namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.MSSQLReflection.Model;

    public class SqlModelSchemaBuilder {
        public SqlModelSchemaBuilder() {
        }

        public void BuildModelSchema(
            ModelSqlDatabase modelDatabase,
            ModelSchema modelSchema,
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors) {
            if (modelSchema == null) { modelSchema = new ModelSchema(); }
            if (metaModelBuilder == null) { metaModelBuilder = new MetaModelBuilder(); }

            // modelDatabase.Freeze();

            foreach (var table in modelDatabase.Tables) {

                var entityTypeModelName = table.Name.GetQFullName(null, 2);
                var entityTypeModelFullName = table.Name.GetQFullName("[", 2);

                var modelComplexType = metaModelBuilder.CreateModelComplexType(
                      entityTypeModelName,
                      entityTypeModelFullName,
                      errors);

                if (modelComplexType.Owner == null) {
                    modelSchema.ComplexTypes.Add(modelComplexType);
                }

                foreach (var column in table.Columns) {

                    ModelScalarType modelScalarType = null;
                    ModelScalarType suggestedType = column.SuggestType(metaModelBuilder);

                    modelScalarType = metaModelBuilder.CreateModelScalarType(
                           entityTypeModelName,
                           entityTypeModelFullName,
                           column.Name.GetQName(),
                           null,
                           column.SqlType.Name.GetQFullName(),
                           suggestedType,
                           column.MaxLength,
                           column.FixedLength,
                           column.Nullable,
                           column.Precision,
                           column.Scale,
                           errors
                           );
                    var columnName = column.Name.GetQFullName(null, 1);
                    var columnExternalName = column.Name.GetQFullName("[", 1);

                    var modelProperty = metaModelBuilder.CreateModelProperty(
                        entityTypeModelName,
                        entityTypeModelFullName,
                        columnName,
                        columnExternalName,
                        errors
                       );
                    if (modelProperty.Type == null) { modelProperty.Type = modelScalarType; }
                    if (modelProperty.Owner == null) {
                        modelComplexType.Properties.Add(modelProperty);
                    }
                }

                var entitySetName = table.Name.GetQFullName(null, 2);
                var modelEntity = metaModelBuilder.CreateModelEntity(
                    entitySetName,
                    ModelEntityKind.EntitySet,
                    errors);
                if (modelEntity.Owner == null) { modelSchema.Entities.Add(modelEntity); }
                modelEntity.EntityType = modelComplexType;
            }
        }

        public void BuildModelSqlDatabase(
            ModelSchema modelSchema,
            ModelSqlDatabase modelDatabase,
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors) {
            foreach (var modelEntitySource in modelSchema.Entities) {
                var modelEntityTypeSource = modelEntitySource.EntityType;
                if (modelEntityTypeSource is null) {
#warning SOON add error
                } else {

                    var tableNameTarget = modelEntitySource.ExternalName ?? modelEntitySource.Name;
                    var sqlTableNameTarget = SqlName.Parse(tableNameTarget, ObjectLevel.Object);
                    var tableTarget = ModelSqlTable.Ensure(modelDatabase, sqlTableNameTarget);

                    foreach (var property in modelEntityTypeSource.Properties) {
                        var sqlColumnNameTarget = SqlName.Parse(property.ExternalName ?? property.Name, ObjectLevel.Object);
                        ModelSqlColumn column = ModelSqlColumn.Ensure(tableTarget, sqlColumnNameTarget.Name);
                        if (property.Type is ModelScalarType propertyScalarType) {
                            var clrTypeSource = property.GetClrType();
                            var typeName = propertyScalarType.Name;
#warning TODO SOON better Scalar Type Handling this is ugly
                            if (!(clrTypeSource is null)) {
                                var innerNullableClrTypeSource = ((clrTypeSource.IsValueType) ? Nullable.GetUnderlyingType(clrTypeSource) : null) ?? clrTypeSource;
                                if (!(column.SqlType is null)) {
                                    var clrScalarTypeTarget = column.SqlType.GetScalarType()?.GetClrType();
                                    var innerNullableClrScalarTypeTarget = ((clrScalarTypeTarget.IsValueType) ? Nullable.GetUnderlyingType(clrScalarTypeTarget) : null) ?? clrScalarTypeTarget;
                                    if (!(clrScalarTypeTarget is null) && (clrScalarTypeTarget.IsAssignableFrom(innerNullableClrScalarTypeTarget))) {
                                        // ok 
                                    } else {
                                        column.SqlType = null;
                                    }
                                }
                            }
                            if (column.SqlType is null) {
                                var sqlTypeTarget = modelDatabase.Types.GetValueOrDefault(SqlName.Parse(typeName, ObjectLevel.Object));
                                if (!(sqlTypeTarget is null)) {
                                    column.SqlType = sqlTypeTarget;
                                } else {
                                    if (!(clrTypeSource is null)) {
                                        var innerNullableClrTypeSource = ((clrTypeSource.IsValueType) ? Nullable.GetUnderlyingType(clrTypeSource) : null) ?? clrTypeSource;
                                        var lstTypes = new List<ModelSqlType>();
                                        foreach (var type in modelDatabase.Types) {
                                            var clrScalarTypeTarget = type.GetScalarType()?.GetClrType();
                                            if (clrScalarTypeTarget is null) {
                                                continue;
                                            }
                                            var innerNullableClrScalarTypeTarget = ((clrScalarTypeTarget.IsValueType) ? Nullable.GetUnderlyingType(clrScalarTypeTarget) : null) ?? clrScalarTypeTarget;
                                            if (innerNullableClrTypeSource.Equals(innerNullableClrScalarTypeTarget)) {
                                                lstTypes.Add(type);
                                            } else if (innerNullableClrTypeSource.IsAssignableFrom(innerNullableClrScalarTypeTarget)) {
                                                lstTypes.Add(type);
                                            }
                                        }
                                        if (lstTypes.Count == 1) {
                                            sqlTypeTarget = lstTypes[0];
                                            column.SqlType = sqlTypeTarget;
                                        } else if (lstTypes.Count > 1) {
                                            sqlTypeTarget = null;
                                            if (clrTypeSource == typeof(string)) {
                                                sqlTypeTarget = modelDatabase.Types.GetValueOrDefault(SqlName.Parse("[sys].[nvarchar]", ObjectLevel.Object));
                                            } else if (clrTypeSource == typeof(DateTime)) {
                                                sqlTypeTarget = modelDatabase.Types.GetValueOrDefault(SqlName.Parse("[sys].[datetime2]", ObjectLevel.Object));
                                            } else if (clrTypeSource == typeof(DateTime?)) {
                                                sqlTypeTarget = modelDatabase.Types.GetValueOrDefault(SqlName.Parse("[sys].[datetime2]", ObjectLevel.Object));
                                            }
                                            if (sqlTypeTarget is null) {
                                                sqlTypeTarget = lstTypes[0];
                                            }
                                            column.SqlType = sqlTypeTarget;
                                        } else {
                                            errors.Add(new ModelErrorInfo($"Unknown mapping for {typeName} - {clrTypeSource}.", column.NameSql));
                                            sqlTypeTarget = modelDatabase.Types.GetValueOrDefault(SqlName.Parse("[sys].[nvarchar]", ObjectLevel.Object));
                                            column.SqlType = sqlTypeTarget;
                                        }
                                    }
                                }
                                sqlTypeTarget = column.SqlType;
                                if (sqlTypeTarget is null) {
                                    errors.Add(new ModelErrorInfo($"column.SqlType is null.", column.NameSql));
                                } else {
                                    sqlTypeTarget.Nullable = propertyScalarType.Nullable.GetValueOrDefault(true);
                                    sqlTypeTarget.MaxLength = propertyScalarType.MaxLength;
                                }
                            } // if (column.SqlType is null)
                        }
                    } // foreach modelEntityTypeSource.Properties

                    if (modelEntityTypeSource.Keys.Count == 0) {
                        errors.Add(new ModelErrorInfo($"no keys defined.", modelEntityTypeSource.Name));
                    }
                    foreach (var key in modelEntityTypeSource.Keys) {
                    }
                }
            }
        }
    }
}
