namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Model;

    public class EdmxModelSchemaBuilder {
        public EdmxModelSchemaBuilder() {
        }

        public ModelSchema Build(
            EdmxModel edmxModel,
            ModelSchema modelSchema,
            //MetaMappingSchema metaMappingSchema,
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors) {
            if (modelSchema == null) { modelSchema = new ModelSchema(); }
            //if (metaMappingSchema == null) { metaMappingSchema = new MetaMappingSchema(); }
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

            foreach (var dataServices in edmxModel.DataServices) {
                foreach (var scalarTypeModel in dataServices.ScalarTypeModel) {
                    this.BuildScalarType(edmxModel, modelSchema, scalarTypeModel, metaModelBuilder, errors);
                }
                foreach (var entityTypeModel in dataServices.EntityType) {
                    this.BuildComplexType(edmxModel, modelSchema, entityTypeModel, metaModelBuilder, errors);
                }
                foreach (var association in dataServices.Association) {
                }
                foreach (var entityContainer in dataServices.EntityContainer) {
                    if (entityContainer.IsDefaultEntityContainer) { continue; }
                }
            }


            foreach (var entitySet in defaultEntityContainer.EntitySet) {
                var entityTypeModel = entitySet.EntityTypeModel;
                if (entityTypeModel == null) {
                    errors.AddErrorOrThrow("entitySet.EntityTypeModel not found", entitySet.Name);
                } else {
                    var entityTypeModelName = entityTypeModel.Name;
                    var entityTypeModelFullName = entityTypeModel.FullName;

                    var modelComplexType = this.BuildComplexType(edmxModel, modelSchema, entityTypeModel, metaModelBuilder, errors);

                    var entitySetName = entitySet.Name;
                    var modelEntity = metaModelBuilder.CreateModelEntity(
                        entitySetName,
                        ModelEntityKind.EntitySet,
                        errors);
                    if (modelEntity.Owner == null) { modelSchema.Entities.Add(modelEntity); }
                    if (modelComplexType is null) {
                        errors.AddErrorOrThrow($"{entityTypeModelFullName ?? entityTypeModelName} not found", entitySet.Name);
                    } else {
                        modelEntity.EntityType = modelComplexType;
                    }
                }
            }

            return modelSchema;
        }

        public ModelScalarType BuildScalarType(EdmxModel edmxModel, ModelSchema modelSchema, CsdlScalarTypeModel scalarTypeModel, MetaModelBuilder metaModelBuilder, ModelErrors errors) {
            if (string.Equals(scalarTypeModel.Namespace, "Edm", StringComparison.Ordinal)) { return null; }
            var name = scalarTypeModel.Name;
            var fullName = scalarTypeModel.FullName;
            ModelScalarType result = new ModelScalarType();
            result.Name = name;
            result.ExternalName = fullName;
            //result.MaxLength = scalarTypeModel.FullName
            modelSchema.ScalarTypes.Add(result);
            return result;
        }

        public ModelComplexType BuildComplexType(EdmxModel edmxModel, ModelSchema modelSchema, CsdlEntityTypeModel entityTypeModel, MetaModelBuilder metaModelBuilder, ModelErrors errors) {

            var entityTypeModelName = entityTypeModel.Name;
            var entityTypeModelFullName = entityTypeModel.FullName;

            var lstFound = modelSchema.ComplexTypes.FindByKey2(entityTypeModelFullName ?? entityTypeModelName);
            if (lstFound.Count == 1) {
                return lstFound[0];
            } else if (lstFound.Count > 1) {
                errors.AddErrorOrThrow(new ModelErrorInfo($"found key {entityTypeModelFullName ?? entityTypeModelName} #{lstFound.Count} times.", entityTypeModelFullName ?? entityTypeModelName));
                return lstFound[0];
            }

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
                    null,
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
                    null,
                    errors
                   );
                if (modelProperty.Type == null) { modelProperty.Type = modelScalarType; }
                if (modelProperty.Owner == null) {
                    modelComplexType.Properties.Add(modelProperty);
                }
            }
            foreach (var keyModel in entityTypeModel.Keys) {
                var modelKey = metaModelBuilder.CreateModelPrimaryKey(
                    entityTypeModelName,
                    entityTypeModelFullName,
                    keyModel.Name,
                    null,
                    //keyModel.Property,
                    errors
                   );
                if (modelKey.Owner == null) {
                    modelComplexType.Keys.Add(modelKey);
                }
            }

            // TODO: NavigationProperty
            foreach (var navigationProperty in entityTypeModel.NavigationProperty) {
                if (navigationProperty.RelationshipName is null) {
                    throw new NotImplementedException("v4 NavigationProperty");
                } else {
                    // v3
                    if (navigationProperty.FromRoleModel is null) {
                    } else {
                        //navigationProperty.FromRoleModel.Multiplicity
                        //navigationProperty.FromRoleName
                    }

                    if (navigationProperty.ToRoleModel is null) {
                    } else {
                    }
                }
            }
            /*
            */
            return modelComplexType;
        }
    }
}
