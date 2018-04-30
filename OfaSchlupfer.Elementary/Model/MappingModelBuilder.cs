namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OfaSchlupfer.Freezable;

    public class MappingModelBuilder {
        public IModelBuilderNamingService NamingServiceTarget;
        private HashSet<string> _KnownEntityMappingSourceName;
        private HashSet<string> _KnownComplexTypeMappingSourceName;

        public MappingModelBuilder(MappingModelRepository mappingModelRepository = null) {
            this.MappingModelRepository = mappingModelRepository;
            //this.EnabledForCreatedMappingModelSchema = true;
        }

        public MappingModelRepository MappingModelRepository { get; set; }

        public string Comment { get; set; }

        public bool EnabledForCreatedMappings { get; set; }
        public bool EnabledForCreatedMappingModelSchema { get; set; }
        public bool EnabledForCreatedMappingModelEntity { get; set; }
        public bool EnabledForCreatedMappingModelComplexType { get; set; }
        public bool EnabledForCreatedMappingModelProperty { get; set; }

        private string GetComment() {
            if (string.IsNullOrEmpty(this.Comment)) {
                return this.Comment = ("Generated" + System.DateTime.Now.ToString("s"));
            }
            return this.Comment;
        }
        /// <summary>
        /// magic
        /// </summary>
        /// <param name="errors">errors</param>
        public void Build(
            ModelErrors errors
            ) {
            if (this.MappingModelRepository is null) { throw new ArgumentNullException(nameof(this.MappingModelRepository)); }
            var repositorySource = this.MappingModelRepository.Source ?? throw new ArgumentNullException(nameof(this.MappingModelRepository.Source));
            var repositoryTarget = this.MappingModelRepository.Target ?? throw new ArgumentNullException(nameof(this.MappingModelRepository.Target));
            if (repositoryTarget.ModelSchema is null) {
                repositoryTarget.CreateModelSchema(null);
            }
            this.NamingServiceTarget = this.MappingModelRepository.Target.GetNamingService(this.MappingModelRepository);

            var lstMappingModelSchema = this.MappingModelRepository.ModelSchemaMappings;

            if (lstMappingModelSchema.Count == 0) {
                this.MappingModelRepository.CreateMappingModelSchema(
                    null,
                    repositorySource.ModelSchema,
                    repositoryTarget.ModelSchema,
                    this.EnabledForCreatedMappings || this.EnabledForCreatedMappingModelSchema,
                    true,
                    this.GetComment());
            }
            {
                var lstMappingModelSchemaEnabled = lstMappingModelSchema.Where(_ => _.Enabled).ToList();
                foreach (var mappingModelSchema in lstMappingModelSchemaEnabled) {
                    var knownEntityMappingSourceName = new HashSet<string>();
                    foreach (var entityMapping in mappingModelSchema.EntityMappings) {
                        knownEntityMappingSourceName.Add(entityMapping.SourceName);
                    }
                    this._KnownEntityMappingSourceName = knownEntityMappingSourceName;

                    var knownComplexTypeMappingSourceName = new HashSet<string>();
                    foreach (var complexTypeMapping in mappingModelSchema.ComplexTypeMappings) {
                        knownComplexTypeMappingSourceName.Add(complexTypeMapping.SourceName);
                    }
                    this._KnownComplexTypeMappingSourceName = knownComplexTypeMappingSourceName;
                }
            }
            {
                var lstMappingModelSchemaEnabled = lstMappingModelSchema.Where(_ => _.Enabled).ToList();
                foreach (var mappingModelSchemaEnabled in lstMappingModelSchemaEnabled) {
                    this.BuildSchema(mappingModelSchemaEnabled, errors);
                }

            }
            //this.BuildSchema(this.MappingModelRepository.MappingModelSchema, source.ModelSchema, target.ModelSchema, errors);
            //errors.AddErrorOrThrow(new ModelErrorInfo("", ""));
        }

        public void BuildSchema(
            MappingModelSchema mappingModelSchema,
            ModelErrors errors
            ) {
            this.BuildEntities(mappingModelSchema, errors);
            this.BuildComplexTypes(mappingModelSchema, errors);
        }

        public void BuildEntities(
            MappingModelSchema mappingModelSchema,
            ModelErrors errors
            ) {
            ModelSchema modelSchemaSource = mappingModelSchema.Source;
            ModelSchema modelSchemaTarget = mappingModelSchema.Target;

            var lstEntityMappings = mappingModelSchema.EntityMappings.Where(_ => _.Enabled).ToList();
            foreach (var entityMapping in lstEntityMappings) {
                if (entityMapping.Target is null) {
                    var targetName = entityMapping.TargetName;
                    string extenalName = targetName;
                    string typeName = null;
#warning SOON thinkof what's in the mapping.
                    if (this.NamingServiceTarget.EntitiesHaveFakeComplexTypes) {
                        typeName = targetName;
                    }
                    modelSchemaTarget.CreateEntity(targetName, extenalName, typeName);
                }
            }

            foreach (var entitySource in modelSchemaSource.Entities) {
                if (this._KnownEntityMappingSourceName.Contains(entitySource.Name)) {
                    continue;
                }

                (string targetName, string extenalName, string typeName, string typeExternalName) = this.NamingServiceTarget.SuggestEntityName(entitySource.Name);

                if (typeName is null && this.NamingServiceTarget.EntitiesHaveFakeComplexTypes) {
                    typeName = targetName;
                }

                var entityMapping = mappingModelSchema.CreateEntityMapping(
                    null,
                    entitySource.Name,
                    targetName,
                    this.EnabledForCreatedMappings || this.EnabledForCreatedMappingModelEntity,
                    true,
                    this.GetComment()
                    );
                if (entityMapping.Enabled) {
                    if (entityMapping.Target is null) {
                        modelSchemaTarget.CreateEntity(entityMapping.TargetName, extenalName, typeName);
                    }
                }
                if (this._KnownComplexTypeMappingSourceName.Contains(entitySource.EntityTypeName)) {
                    // if there is a rule ... ok
                } else {
                    var complexTypeSource = entitySource.EntityType;
                    if (complexTypeSource is null) {
#warning SOON error??
                        errors.AddErrorOrThrow($"EntityType {entitySource.EntityTypeName} does not exists.", entitySource.Name);
                    } else {
                        var complexTypeMapping = mappingModelSchema.CreateComplexTypeMapping(
                                null,
                                complexTypeSource.Name,
                                typeName,
                                this.EnabledForCreatedMappings || this.EnabledForCreatedMappingModelComplexType,
                                true,
                                this.GetComment()
                            );
                        this._KnownComplexTypeMappingSourceName.Add(complexTypeSource.Name);
                        if (complexTypeMapping.Enabled && !string.IsNullOrEmpty(complexTypeMapping.TargetName)) {
                            if (complexTypeMapping.Target is null) {
                                modelSchemaTarget.CreateComplexType(complexTypeMapping.TargetName ?? typeName, typeExternalName);
                            }
                            if ((!(complexTypeMapping.Source is null))
                                && (!(complexTypeMapping.Target is null))
                                ) {
                                this.BuildComplexTypeProperties(complexTypeMapping, errors);
                                this.BuildComplexTypeIndexes(complexTypeMapping, errors);
                            } else {
                                if (complexTypeMapping.Source is null) {
                                    errors.AddErrorOrThrow($"complexTypeMapping.Source {complexTypeMapping.SourceName} is null", $"complexTypeMapping.Name: {complexTypeMapping.Name}");
                                }
                                if (complexTypeMapping.Target is null) {
                                    errors.AddErrorOrThrow($"complexTypeMapping.Target {complexTypeMapping.TargetName} is null", $"complexTypeMapping.Name: {complexTypeMapping.Name}");
                                }
                            }
                        }
                    }
                }
            }

#if weichei
            var mappingByNameSource = mappingModelSchema.EntityMappings.ToDictionary(_ => _.SourceName, StringComparer.OrdinalIgnoreCase);
            foreach (var entitySource in modelSchemaSource.Entities) {
                var entityMapping = mappingByNameSource.GetValueOrDefault(entitySource.Name);

                // magic needed here
                var entityNameTarget = entitySource.Name;

                if (entityMapping is null || entityMapping.Target is null) {
                    var lstEntityTarget = modelSchemaTarget.Entities.FindByKey(entityNameTarget);
                    if (lstEntityTarget.Count == 0) {
                        var entityTarget = modelSchemaTarget.CreateEntity(entityNameTarget);
                        // magic needed here
                        entityTarget.EntityTypeName = entitySource.EntityTypeName;
                        if (entityMapping is null) {
                            mappingModelSchema.CreateEntityMapping(null, entitySource, entityTarget, true, true, "TODO");
                        } else {
                            entityMapping.Target = entityTarget;
                        }
                    } else if (lstEntityTarget.Count == 1) {
                        var entityTarget = lstEntityTarget[0];
                        if (entityMapping is null) {
                            mappingModelSchema.CreateEntityMapping(null, entitySource, entityTarget, true,true,"TODO");
                        } else {
                            entityMapping.Target = entityTarget;
                        }
                    } else {
                        throw new NotImplementedException(" rule feedback any idea?? error???");
                    }
                } else {
                    // ??
                }
            }
#endif
        }

        public void BuildComplexTypes(
            MappingModelSchema mappingModelSchema,
            ModelErrors errors
            ) {
            ModelSchema modelSchemaSource = mappingModelSchema.Source;
            ModelSchema modelSchemaTarget = mappingModelSchema.Target;

            var lstComplexTypeMappingsEnabled = mappingModelSchema.ComplexTypeMappings.Where(_ => _.Enabled).ToList();
            foreach (var complexTypeMapping in lstComplexTypeMappingsEnabled) {
                if (complexTypeMapping.Target is null) {
                    var targetName = complexTypeMapping.TargetName;
                    string extenalName = targetName;
                    modelSchemaTarget.CreateComplexType(targetName, extenalName);
                }
            }

            foreach (var complexTypeSource in modelSchemaSource.ComplexTypes) {
                if (this._KnownComplexTypeMappingSourceName.Contains(complexTypeSource.Name)) {
                    continue;
                }

                (string targetName, string extenalName) = this.NamingServiceTarget.SuggestComplexType(complexTypeSource.Name);

                var complexTypeMapping = mappingModelSchema.CreateComplexTypeMapping(
                        null,
                        complexTypeSource.Name,
                        targetName,
                        this.EnabledForCreatedMappings || this.EnabledForCreatedMappingModelComplexType,
                        true,
                        this.GetComment()
                    );
                this._KnownComplexTypeMappingSourceName.Add(complexTypeSource.Name);
                if (complexTypeMapping.Enabled) {
                    if (complexTypeMapping.Target is null) {
                        modelSchemaTarget.CreateComplexType(complexTypeMapping.TargetName, extenalName);
                    }
                    if ((!(complexTypeMapping is null))
                        && (!(complexTypeMapping.Source is null))
                        && (!(complexTypeMapping.Target is null))
                        ) {
                        this.BuildComplexTypeProperties(complexTypeMapping, errors);
                        this.BuildComplexTypeIndexes(complexTypeMapping, errors);
                    }
                }
            }

            return;
#warning SOON this is the old Logic -> copy from this.BuildEntities
#if weichei

            var mappingByNameSource = mappingModelSchema.ComplexTypeMappings.ToDictionary(_ => _.SourceName, StringComparer.OrdinalIgnoreCase);
            foreach (var complexTypeSource in modelSchemaSource.ComplexTypes) {
                var complexTypeMapping = mappingByNameSource.GetValueOrDefault(complexTypeSource.Name);

                // magic needed here
                var complexTypeNameTarget = complexTypeSource.Name;

                if (complexTypeMapping is null || complexTypeMapping.Target is null) {
                    var lstComplexType = modelSchemaTarget.ComplexTypes.FindByKey(complexTypeNameTarget);
                    if (lstComplexType.Count == 0) {
                        var complexTypeTarget = modelSchemaTarget.CreateComplexType(complexTypeNameTarget, null);
                        if (complexTypeMapping is null) {
                            complexTypeMapping = mappingModelSchema.CreateComplexTypeMapping(
                                null,
                                complexTypeSource,
                                complexTypeTarget,
                                true,
                                true,
                                "TODO");
                        } else {
                            complexTypeMapping.Target = complexTypeTarget;
                        }
                    } else if (lstComplexType.Count == 1) {
                        var complexTypeTarget = lstComplexType[0];
                        if (complexTypeMapping is null) {
                            mappingModelSchema.CreateComplexTypeMapping(
                                null,
                                complexTypeSource,
                                complexTypeTarget,
                                true,
                                true,
                                "TODO");
                        } else {
                            complexTypeMapping.Target = complexTypeTarget;
                        }
                    } else {
                        throw new NotImplementedException(" rule feedback any idea?? error???");
                    }
                } else {
                    // ??
                }
                if ((!(complexTypeMapping is null))
                    && (!(complexTypeMapping.Source is null))
                    && (!(complexTypeMapping.Target is null))
                    ) {
                    this.BuildComplexTypeProperties(complexTypeMapping, errors);
                }
            }
#endif
#if weichei

            //foreach (var entityMapping in mappingModelSchema.EntityMappings) {
            //    entityMapping.Source
            //}

            //modelSchemaSource.ComplexTypes
            //modelSchemaSource.Relations

            /*
        foreach (var complexTypeSource in modelSchemaSource.ComplexTypes) {
            var complexTypeTarget = new ModelComplexType();
            complexTypeTarget.Name = complexTypeSource.Name;
            complexTypeTarget.ExternalName = complexTypeSource.ExternalName;
            //
            var lstComplexTypeTargetFound = modelSchemaTarget.ComplexTypes.FindByKey(complexTypeSource.Name);
            if (lstComplexTypeTargetFound.Count == 0) {
                modelSchemaTarget.ComplexTypes.Add(complexTypeTarget);

                var mappingModelComplexType = new MappingModelComplexType() {
                    Enabled = true,
                    Source = complexTypeSource,
                    Target = complexTypeTarget
                };

#warning where to store mappingModelComplexType

            } else if (lstComplexTypeTargetFound.Count > 1) {
                throw new NotImplementedException("(lstComplexTypeTargetFound.Count > 1)");
            } else {
                complexTypeTarget = lstComplexTypeTargetFound[0];
            }
        }
        */

            //            var modelSchemaMappings = (this.MappingModelRepository.ModelSchemaMappings.Where(_ => _.Name == modelSchemaSource.Name)).ToList();
            //            var modelSchemaMappingsDisabled = modelSchemaMappings.Where(_ => _.Disabled).ToList();
            //            var modelSchemaMappingsEnabled = modelSchemaMappings.Where(_ => !_.Disabled).ToList();

            //            foreach (var modelSchemaMapping in modelSchemaMappingsEnabled) {
            //            }




            //            foreach (var entitySource in modelSchemaSource.Entities) {
            //                var entitySourceName = entitySource.Name;

            //                ModelEntity entityTarget = new ModelEntity();
            //                entityTarget.Kind = entitySource.Kind;
            //                entityTarget.Name = entitySource.Name;
            //                entityTarget.ExternalName = entitySource.ExternalName;

            //                // entityTarget.EntityType = sourceEntity.EntityType;
            //                entityTarget.EntityTypeName = entitySource.EntityTypeName;

            //                modelSchemaTarget.Entities.Add(entityTarget);
            //                var mappingModelEntity = new MappingModelEntity() {
            //                    Enabled = true,
            //                    Source = entitySource,
            //                    Target = entityTarget
            //                };
            //#warning where to store mappingModelEntity
            //            }
#endif
        }

        public void BuildComplexTypeProperties(MappingModelComplexType complexTypeMapping, ModelErrors errors) {
            ModelComplexType complexTypeSource = complexTypeMapping.Source;
            ModelComplexType complexTypeTarget = complexTypeMapping.Target;
            var mappingByNameSource = complexTypeMapping.PropertyMappings.ToDictionary(_ => _.SourceName, StringComparer.OrdinalIgnoreCase);

            foreach (var propertySource in complexTypeSource.Properties) {
                var propertyMapping = mappingByNameSource.GetValueOrDefault(propertySource.Name);

                var propertyExternalNameTarget = propertySource.Name;
#warning magic needed here
                var propertyNameTarget = propertyExternalNameTarget;

                if (propertyMapping is null || propertyMapping.Target is null) {
                    var lstProperty = complexTypeTarget.Properties.FindByKey(propertyNameTarget);
                    if (lstProperty.Count == 0) {
                        var propertyTarget = complexTypeTarget.CreateProperty(propertyNameTarget, propertyExternalNameTarget);
#warning                        //entityTarget.Type = propertySource.Type;

                        propertyTarget.Type = this.BuildScalarType(propertySource.Type);
                        if (propertyMapping is null) {
                            complexTypeMapping.CreatePropertyMapping(null, propertySource, propertyTarget);
                        } else {
                            propertyMapping.Target = propertyTarget;
                        }
                    } else if (lstProperty.Count == 1) {
                        var propertyTarget = lstProperty[0];
                        if (propertyMapping is null) {
                            complexTypeMapping.CreatePropertyMapping(null, propertySource, propertyTarget);
                        } else {
                            propertyMapping.Target = propertyTarget;
                        }
                    } else {
                        throw new NotImplementedException(" rule feedback any idea?? error???");
                    }
                } else {
                    // ??
                }
            }
        }
        public void BuildComplexTypeIndexes(MappingModelComplexType complexTypeMapping, ModelErrors errors) {
            ModelComplexType complexTypeSource = complexTypeMapping.Source;
            ModelComplexType complexTypeTarget = complexTypeMapping.Target;
            var mappingByNameSource = complexTypeMapping.IndexMappings.ToDictionary(_ => _.SourceName, StringComparer.OrdinalIgnoreCase);

            foreach (var indexMapping in complexTypeMapping.IndexMappings.Where(_ => _.Enabled)) {
                if (!(indexMapping.Source is null) && (indexMapping.Target is null) && !(indexMapping.TargetName is null)) {
                    complexTypeTarget.CreateIndex(indexMapping.TargetName, null);
#warning here
                    this.BuildComplexTypeIndexProperties(indexMapping, errors);
                    //complexTypeMapping.CreatePropertyMapping(null, null, null);
                    //complexTypeTarget.Indexes.Add
                    //complexTypeMapping
                }
            }


            foreach (var indexSource in complexTypeSource.Indexes) {
                var indexMapping = mappingByNameSource.GetValueOrDefault(indexSource.Name);
                if (!(indexMapping is null) && indexMapping.Enabled) { continue; }

                var indexExternalNameTarget = indexSource.Name;
#warning magic needed here
                var indexNameTarget = indexExternalNameTarget;

                if (indexMapping is null || indexMapping.Target is null) {
                    var lstFound = complexTypeTarget.Indexes.FindByKey(indexNameTarget);
                    if (lstFound.Count == 0) {
                        var indexTarget = complexTypeTarget.CreateIndex(indexNameTarget, indexExternalNameTarget);
                        if (indexMapping is null) {
                            indexMapping = complexTypeMapping.CreateIndexMapping(null, indexSource, indexTarget);
                        } else {
                            indexMapping.Target = indexTarget;
                        }
                    } else if (lstFound.Count == 1) {
                        var indexTarget = lstFound[0];
                        if (indexMapping is null) {
                            indexMapping = complexTypeMapping.CreateIndexMapping(null, indexSource, indexTarget);
                        } else {
                            indexMapping.Target = indexTarget;
                        }
                    } else {
                        throw new NotImplementedException(" rule feedback any idea?? error???");
                    }
                } else {
                    // ??
                }
                if (!(indexMapping is null)) {
                    this.BuildComplexTypeIndexProperties(indexMapping, errors);
                }
            }

        }

        public void BuildComplexTypeIndexProperties(MappingModelIndex indexMapping, ModelErrors errors) {
            var indexMappingSource = indexMapping.Source;
            var indexMappingTarget = indexMapping.Target;

            var mappingPropertySource = indexMapping.Owner.PropertyMappings.Where(_ => _.Enabled).ToDictionary(_ => _.SourceName, StringComparer.OrdinalIgnoreCase);
            foreach (var indexPropertySource in indexMappingSource.Properties) {
                var mappingProperty = mappingPropertySource.GetValueOrDefault(indexPropertySource.Name);
                if (!(mappingProperty is null) && !(mappingProperty.Target is null)) {
                    var lstFound = indexMappingTarget.Properties.FindByKey(mappingProperty.TargetName);
                    if (lstFound.Count == 0) {
                        indexMappingTarget.Properties.Add(new ModelIndexProperty() {
                            Property = mappingProperty.Target,
                            Ascending = indexPropertySource.Ascending,
                        });
                    }
                }
            }
            //var mappingSource = indexMapping.IndexColumnMappings.ToDictionary(_ => _.SourceName, StringComparer.OrdinalIgnoreCase);
            //foreach (var indexPropertySource in indexMappingSource.Properties) {
            //var indexPropertyMapping = mappingSource.GetValueOrDefault(indexPropertySource.Name);
            //if (indexPropertyMapping is null || indexPropertyMapping.Target is null) {
            //    var lstFound = indexMappingTarget.Properties.FindByKey(in)
            //    var indexPropertyTarget
            //    indexPropertyMapping = indexMapping.CreateIndexColumnMapping(null, indexPropertySource, null);
            //}
            //}
        }

        private ModelType BuildScalarType(ModelType type) {
            if (type is null) { return null; }
            if (type is ModelScalarType modelScalarType) {
#warning TODO handle owner
                var result = new ModelScalarType(modelScalarType);
                return result;
            }
            throw new NotImplementedException(type.GetType().Name);
        }
    }
}
