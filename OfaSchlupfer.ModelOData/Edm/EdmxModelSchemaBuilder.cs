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
                defaultEntityContainers = edmxModel.DataServices.SelectMany(_ => _.EntityContainer).ToList();
            }
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
            }
            foreach (var dataServices in edmxModel.DataServices) {
                foreach (var entityTypeModel in dataServices.EntityType) {
                    this.BuildComplexType(edmxModel, modelSchema, entityTypeModel, metaModelBuilder, errors);
                }
            }
            foreach (var dataServices in edmxModel.DataServices) {
                foreach (var entityTypeModel in dataServices.EntityType) {
                    this.BuildComplexTypeNavigationProperty(edmxModel, modelSchema, entityTypeModel, metaModelBuilder, errors);
                }
            }
            foreach (var dataServices in edmxModel.DataServices) {
                foreach (var association in dataServices.Association) {
                    this.BuildAssociation(edmxModel, modelSchema, association, metaModelBuilder, errors);
                }
            }
            //foreach (var dataServices in edmxModel.DataServices) {
            //    foreach (var entityContainer in dataServices.EntityContainer) {
            //        if (entityContainer.IsDefaultEntityContainer) { continue; }
            //    }
            //}


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

            //foreach (var associationSet in defaultEntityContainer.AssociationSet) {
            //    foreach (var end in associationSet.End) {
            //        if (!(end.EntitySetModel is null)) {
            //            var roleName = d.RoleName;
            //        }
            //    }
            //}

            return modelSchema;
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
            var primaryKey = entityTypeModel.Keys;
            if (primaryKey.Count > 0) {
                var modelIndex = metaModelBuilder.CreateModelIndex(
                    entityTypeModelName,
                    entityTypeModelFullName,
                    "PrimaryKey",
                    null,
                    errors
                    );
                modelIndex.IsPrimaryKey = true;
                if (modelIndex.Owner == null) {
                    modelComplexType.Indexes.Add(modelIndex);
                }
                foreach (var keyModel in entityTypeModel.Keys) {
                    var modelIndexProperty = metaModelBuilder.CreateModelIndexProperty(
                        entityTypeModelName,
                        entityTypeModelFullName,
                        modelIndex.Name,
                        modelIndex.ExternalName,
                        keyModel.Name,
                        null,
                        //keyModel.Property,
                        errors
                       );
                    if (modelIndexProperty.Owner == null) {
                        modelIndex.Properties.Add(modelIndexProperty);
                    }
                }
            }

            return modelComplexType;
        }


        public ModelComplexType BuildComplexTypeNavigationProperty(EdmxModel edmxModel, ModelSchema modelSchema, CsdlEntityTypeModel entityTypeModel, MetaModelBuilder metaModelBuilder, ModelErrors errors) {

            ModelComplexType result = null;
            var entityTypeModelName = entityTypeModel.Name;
            var entityTypeModelFullName = entityTypeModel.FullName;

            var lstFound = modelSchema.ComplexTypes.FindByKey2(entityTypeModelFullName ?? entityTypeModelName);
            if (lstFound.Count == 1) {
                result = lstFound[0];
            } else if (lstFound.Count > 1) {
                errors.AddErrorOrThrow(new ModelErrorInfo($"found key {entityTypeModelFullName ?? entityTypeModelName} #{lstFound.Count} times.", entityTypeModelFullName ?? entityTypeModelName));
                result = lstFound[0];
            } else {
                result = BuildComplexType(edmxModel, modelSchema, entityTypeModel, metaModelBuilder, errors);
            }
            if (result == null) { return null; }

            foreach (var navigationProperty in entityTypeModel.NavigationProperty) {
                if (navigationProperty.RelationshipName is null) {
                    //navigationProperty.Name
                    //navigationProperty.TypeModel
                    //navigationProperty.PartnerModel
                    throw new NotImplementedException("v4 NavigationProperty");
                } else {
                    // v3
                    //if (navigationProperty.FromRoleModel is null) {
                    //} else {                    
                    //}

                    if (navigationProperty.ToRoleModel is null) {
                    } else {
                        var toModel = navigationProperty.ToRoleModel.TypeModel;
                        var lstToComplexTypes = modelSchema.ComplexTypes.FindByKey2(toModel.FullName);
                        if (lstToComplexTypes.Count == 1) {
                            var toComplexType = lstToComplexTypes[0];
                            var navigationPropertyExternalName = navigationProperty.Name;
#warning magic needed here
                            var navigationPropertyName = navigationPropertyExternalName;

                            bool isCollection = false;
                            bool isOptional = false;
                            switch (navigationProperty.ToRoleModel.GetMultiplicity()) {
                                case MultiplicityKind.Unknown:
                                    break;
                                case MultiplicityKind.OneOptional:
                                    isOptional = true;
                                    break;
                                case MultiplicityKind.One:
                                    break;
                                case MultiplicityKind.Multiple:
                                    isCollection = true;
                                    break;
                                default:
                                    break;
                            }

                            var modelNavigationProperty = result.CreateNavigationProperty(
                                navigationPropertyName,
                                navigationPropertyExternalName,
                                toComplexType,
                                isOptional,
                                isCollection
                                );
                        }
                    }
                }
            }
            /*
            */
            return result;
        }

        public ModelScalarType BuildScalarType(EdmxModel edmxModel, ModelSchema modelSchema, CsdlScalarTypeModel scalarTypeModel, MetaModelBuilder metaModelBuilder, ModelErrors errors) {
            if (string.Equals(scalarTypeModel.Namespace, "Edm", StringComparison.Ordinal)) { return null; }
            //
#warning  BuildScalarType - when does this happen?
            var name = scalarTypeModel.Name;
            var fullName = scalarTypeModel.FullName;
            ModelScalarType result = new ModelScalarType {
                Name = name,
                ExternalName = fullName
            };
            modelSchema.ScalarTypes.Add(result);
            return result;
        }

        public void BuildAssociation(EdmxModel edmxModel, ModelSchema modelSchema, CsdlAssociationModel association, MetaModelBuilder metaModelBuilder, ModelErrors errors) {
            foreach (var associationEnd in association.AssociationEnd) {
                if (associationEnd.TypeModel is null) {
                    if (!(associationEnd.TypeName is null)) {
                        errors.AddErrorOrThrow($"{associationEnd.TypeName} not found.", $"{association.FullName} - {associationEnd.FullName}");
                    }
                    continue;
                }
                //associationEnd.GetMultiplicity()
                //var roleName = associationEnd.RoleName;
                //associationEnd.TypeModel                
            }
            var lstOneOptional = association.AssociationEnd.Where(end => end.GetMultiplicity() == MultiplicityKind.OneOptional).ToList();
            var lstOne = association.AssociationEnd.Where(end => end.GetMultiplicity() == MultiplicityKind.One).ToList();
            var lstMultiple = association.AssociationEnd.Where(end => end.GetMultiplicity() == MultiplicityKind.Multiple).ToList();
            if ((lstOneOptional.Count == 1) && (lstMultiple.Count == 1)) {
                var masterEnd = lstOneOptional[0];
                var foreignEnd = lstMultiple[0];
                var lstMasterProperty = masterEnd.TypeModel.NavigationProperty.Where(np => np.FromRoleName == masterEnd.RoleName).ToList();
                var lstForeignProperty = foreignEnd.TypeModel.NavigationProperty.Where(np => np.FromRoleName == foreignEnd.RoleName).ToList();
                if ((lstMasterProperty.Count == 1) && (lstForeignProperty.Count == 1)) {


                    //modelSchema.ComplexTypes.FindByKey2(lstMasterProperty[0])
                    //modelSchema.ComplexTypes.FindByKey2(lstMasterProperty[0].TypeModel.Nam)

                    var result = metaModelBuilder.CreateModelRelation(
                        association.Name,
                        association.FullName,
                        lstMasterProperty[0].ToRoleModel.TypeName,
                        lstMasterProperty[0].Name,
                        lstForeignProperty[0].ToRoleModel.TypeName,
                        lstForeignProperty[0].Name
                    );
                    modelSchema.Relations.Add(result);
                }
            }
        }
    }
}
