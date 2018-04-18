namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Model;

    public class EdmxModelBuilder {
        public EdmxModelBuilder() {
        }

        public ModelSchema Build(
            EdmxModel edmxModel,
            ModelSchema modelSchema,
            MetaMappingSchema metaMappingSchema,
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors) {
            if (modelSchema == null) { modelSchema = new ModelSchema(); }
            if (metaMappingSchema == null) { metaMappingSchema = new MetaMappingSchema(); }
            if (metaModelBuilder == null) { metaModelBuilder = new MetaModelBuilder(); }

            if (!edmxModel.IsFrozen()) {
                edmxModel.AddCoreSchemaIfNeeded(errors);
                edmxModel.Freeze();
            }

            var defaultEntityContainers = edmxModel.DataServices.SelectMany(_ => _.EntityContainer).Where(_ => _.IsDefaultEntityContainer).ToList();
            if (defaultEntityContainers.Count != 1) {
                errors.AddErrorOrThrow($"DefaultEntityContainers #{defaultEntityContainers.Count} found.", "model");
                return modelSchema;
            }
            var defaultEntityContainer = defaultEntityContainers[0];

            edmxModel.ResolveNames(errors);
            if (errors.HasErrors()) { return modelSchema; }

            foreach (var entitySet in defaultEntityContainer.EntitySet) {
                var entityTypeModel = entitySet.EntityTypeModel;
                if (entityTypeModel == null) {
                    errors.AddErrorOrThrow("entitySet.EntityTypeModel not found", entitySet.Name);
                } else {
                    var entityTypeModelName = entityTypeModel.Name;
                    var entityTypeModelFullName = entityTypeModel.FullName;

                    var modelComplexType = metaModelBuilder.CreateModelComplexType(
                        entityTypeModelName,
                        entityTypeModelFullName,
                        errors);

                    if (modelComplexType.Owner == null) {
                        modelSchema.ComplexTypes.Add(modelComplexType);
                    }

                    foreach (var property in entityTypeModel.Property) {

                        ModelScalarType modelScalarType = null;
                        ModelScalarType suggestedType = property.SuggestType(metaModelBuilder);

                        // TODO: thinkof EdmxModelBuilder Build ScalarType
                        //if (property.ScalarType != null) {
                        //    property.ScalarType.FullName
                        //}

                        modelScalarType = metaModelBuilder.CreateModelScalarType(
                            entityTypeModelName,
                            entityTypeModelFullName,
                            property.Name,
                            property.TypeName,
                            suggestedType,
                            property.MaxLength,
                            property.FixedLength,
                            property.Nullable,
                            property.Precision,
                            property.Scale,
                            errors
                            );

                        var modelProperty = metaModelBuilder.CreateModelProperty(
                            entityTypeModelName,
                            entityTypeModelFullName,
                            property.Name,
                            errors
                           );
                        if (modelProperty.Type == null) { modelProperty.Type = modelScalarType; }
                        if (modelProperty.Owner == null) {
                            modelComplexType.Properties.Add(modelProperty);
                        }
                    }

                    // TODO: NavigationProperty
                    /*
                    foreach (var navigationProperty in entityTypeModel.NavigationProperty) { }
                    */

                    var entitySetName = entitySet.Name;
                    var modelEntity = metaModelBuilder.CreateModelEntity(
                        entitySetName,
                        errors);
                    if (modelEntity.Owner == null) { modelSchema.Entities.Add(modelEntity); }
                    modelEntity.EntityType = modelComplexType;
                }
            }

            return modelSchema;
        }
    }
}
