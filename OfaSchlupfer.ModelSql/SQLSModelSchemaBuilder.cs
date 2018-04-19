namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.MSSQLReflection.Model;

    public class SQLSModelSchemaBuilder {
        public SQLSModelSchemaBuilder() {
        }

        public void Build(
            ModelSqlDatabase modelDatabase,
            ModelSchema modelSchema,
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors) {
            if (modelSchema == null) { modelSchema = new ModelSchema(); }
            if (metaModelBuilder == null) { metaModelBuilder = new MetaModelBuilder(); }

            // modelDatabase.Freeze();

            foreach (var table in modelDatabase.Tables.Values) {

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
    }
}
