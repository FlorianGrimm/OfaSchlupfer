namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    public class MetaModelBuilder {
        private readonly RulesForKind<ModelEntity> _RulesModelEntity;
        private readonly RulesForKind<ModelComplexType> _RulesModelComplexType;
        private readonly RulesForKind<ModelProperty> _RulesModelProperty;
        private readonly RulesForKind<ModelIndex> _RulesModelIndex;
        private readonly RulesForKind<ModelIndexProperty> _RulesModelIndexProperty;
        private readonly RulesForKind<ModelScalarType> _RulesModelScalarType;
        private readonly RulesForKind<ModelRelation> _RulesModelRelation;

        public MetaModelBuilder() {
            this._RulesModelEntity = new RulesForKind<ModelEntity>();
            this._RulesModelComplexType = new RulesForKind<ModelComplexType>();
            this._RulesModelProperty = new RulesForKind<ModelProperty>();
            this._RulesModelIndex = new RulesForKind<ModelIndex>();
            this._RulesModelIndexProperty = new RulesForKind<ModelIndexProperty>();
            this._RulesModelScalarType = new RulesForKind<ModelScalarType>();
            this._RulesModelRelation = new RulesForKind<ModelRelation>();
        }

        public bool GenerateRules { get; set; }

        public void Initialize(MetaModelBuilderRules rules) {
            if (rules != null) {
                this._RulesModelEntity.Initialize(rules.ModelEntityRules);
                this._RulesModelComplexType.Initialize(rules.ModelComplexTypeRules);
                this._RulesModelProperty.Initialize(rules.ModelPropertyRules);
                this._RulesModelIndex.Initialize(rules.ModelIndexRules);
                this._RulesModelIndexProperty.Initialize(rules.ModelIndexPropertyRules);
                this._RulesModelScalarType.Initialize(rules.ModelScalarTypeRules);
                this._RulesModelRelation.Initialize(rules.ModelRelationRules);
            }
        }

        public MetaModelBuilderRules GetGeneratedRules() {
            var result = new MetaModelBuilderRules();
            result.ModelEntityRules.AddRange(this._RulesModelEntity.GeneratedRules.Values);
            result.ModelComplexTypeRules.AddRange(this._RulesModelComplexType.GeneratedRules.Values);
            result.ModelPropertyRules.AddRange(this._RulesModelProperty.GeneratedRules.Values);
            result.ModelIndexRules.AddRange(this._RulesModelIndex.GeneratedRules.Values);
            result.ModelIndexPropertyRules.AddRange(this._RulesModelIndexProperty.GeneratedRules.Values);
            result.ModelScalarTypeRules.AddRange(this._RulesModelScalarType.GeneratedRules.Values);
            return result;
        }

        public ModelEntity CreateModelEntity(
            string entityName,
            ModelEntityKind modelEntityKind,
            ModelErrors errors) {
            var result = new ModelEntity {
                Name = entityName,
                ExternalName = entityName,
                Kind = modelEntityKind
            };
            return this._RulesModelEntity.HandleRules(result.ExternalName, result, this.GenerateRules);
        }

        public ModelComplexType CreateModelComplexType(
            string complexTypeName,
            string complexTypeExternalName,
            ModelErrors errors) {
            var result = new ModelComplexType {
                Name = complexTypeName,
                ExternalName = complexTypeExternalName ?? complexTypeName
            };
            return this._RulesModelComplexType.HandleRules(result.ExternalName, result, this.GenerateRules);
        }

        public ModelProperty CreateModelProperty(
            string complexTypeName,
            string complexTypeExternalName,
            string propertyName,
            string propertyExternalName,
            ModelErrors errors
            ) {
            var result = new ModelProperty {
                Name = propertyName,
                ExternalName = propertyExternalName ?? propertyName
            };
            var key = (complexTypeExternalName ?? complexTypeName) + "." + result.ExternalName;
            return this._RulesModelProperty.HandleRules(key, result, this.GenerateRules);
        }

        public ModelIndex CreateModelIndex(
            string complexTypeName,
            string complexTypeExternalName,
            string indexName,
            string indexExternalName,
            //CsdlPropertyModel Property,
            ModelErrors errors
            ) {
            var result = new ModelIndex {
                Name = indexName,
                ExternalName = indexExternalName ?? indexName
            };
            var key = (complexTypeExternalName ?? complexTypeName) + "." + result.ExternalName;
            return this._RulesModelIndex.HandleRules(key, result, this.GenerateRules);
        }
        public ModelIndexProperty CreateModelIndexProperty(
            string complexTypeName,
            string complexTypeExternalName,
            string indexName,
            string indexExternalName,
            string propertyName,
            string propertyExternalName,
            //CsdlPropertyModel Property,
            ModelErrors errors
            ) {
#warning here CreateModelIndexProperty think of
            var result = new ModelIndexProperty {
                Name = propertyName,
                ExternalName = propertyExternalName ?? propertyName
            };
            var key = (complexTypeExternalName ?? complexTypeName) + "." + result.ExternalName;
            return this._RulesModelIndexProperty.HandleRules(key, result, this.GenerateRules);
        }

        public ModelScalarType CreateModelScalarType(
            string complexTypeName,
            string complexTypeExternalName,
            string propertyName,
            string propertyExternalName,
            string scalarTypeName,
            ModelScalarType suggestedType,
            short? maxLentgth,
            bool? fixedLength,
            bool? nullable,
            byte? precision,
            byte? scale,
            ModelErrors errors
            ) {
            if (suggestedType != null) {
                var key = (complexTypeExternalName ?? complexTypeName) + "." + (propertyExternalName ?? propertyName) + ":" + scalarTypeName;
                return this._RulesModelScalarType.HandleRules(key, suggestedType, this.GenerateRules);
            } else {
                var result = new ModelScalarType {
                    Name = scalarTypeName,
                    MaxLength = maxLentgth,
                    FixedLength = fixedLength,
                    Nullable = nullable,
                    Precision = precision,
                    Scale = scale
                };
#warning CreateModelScalarType
                var key = (complexTypeExternalName ?? complexTypeName) + "." + (propertyExternalName ?? propertyName) + ":" + scalarTypeName;
                return this._RulesModelScalarType.HandleRules(key, result, this.GenerateRules);
            }
        }

        public ModelScalarType CreateModelScalarType(IModelScalarTypeFacade modelScalarTypeFacade, List<ModelScalarType> results) {
            if (results.Count > 0) {
                return results[0];
            } else {
                return null;
            }
        }

        public ModelRelation CreateModelRelation(
            string associationName,
            string associationExternalName,
            string masterEntityName,
            string masterNavigationPropertyName,
            string foreignEntityName,
            string foreignNavigationPropertyName
            ) {
            var result = new ModelRelation {
                Name = associationName,
                ExternalName = associationExternalName,
                MasterName = masterEntityName,
                MasterNavigationPropertyName = masterNavigationPropertyName,
                ForeignName = foreignEntityName,
                ForeignNavigationPropertyName = foreignNavigationPropertyName
            };
            var key = (associationExternalName ?? associationName);
            return this._RulesModelRelation.HandleRules(key, result, this.GenerateRules);
        }

        private class RulesForKind<T>
            where T: ModelNamedElement
            {
            public readonly Dictionary<string, MetaModelBuilderRule> ExistingsRules;
            public readonly Dictionary<string, MetaModelBuilderRule> GeneratedRules;
            public readonly Dictionary<string, MetaModelBuilderRule> AllRules;
            internal RulesForKind() {
                this.ExistingsRules = new Dictionary<string, MetaModelBuilderRule>();
                this.GeneratedRules = new Dictionary<string, MetaModelBuilderRule>();
                this.AllRules = new Dictionary<string, MetaModelBuilderRule>();
            }
            internal T HandleRules(string key, T result, bool generateRules) {
                var found = this.AllRules.GetValueOrDefault(key);
                if (found is null) {
                    if (generateRules) {
                        var name = result.Name;
                        var externalName = result.ExternalName ?? result.Name;
                        var json = JsonConvert.SerializeObject(result);
                        var rule = new MetaModelBuilderRule {
                            //rule.Kind = nameof(T);
                            SourceKey = key,
                            Name = name,
                            ExternalName = externalName,
                            Result = json,
                            Generated = true
                        };
                        this.AllRules.Add(key, rule);
                        this.GeneratedRules.Add(key, rule);
                        return result;
                    } else {
                        return result;
                    }
                } else if (found.Generated) {
                    return result;
                } else {
                    var alternateRule = JsonConvert.DeserializeObject<T>(found.Result);
                    alternateRule.Name = found.Name;
                    return alternateRule;
                }
            }

            internal void Initialize(List<MetaModelBuilderRule> rules) {
                foreach (var rule in rules) {
                    this.ExistingsRules.Add(rule.SourceKey, rule);
                    this.AllRules.Add(rule.SourceKey, rule);
                }
            }
        }
    }

    [JsonObject]
    public class MetaModelBuilderRules {
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelEntityRules;
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelComplexTypeRules;
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelPropertyRules;
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelIndexRules;
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelIndexPropertyRules;
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelScalarTypeRules;
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelRelationRules;

        public MetaModelBuilderRules() {
            this.ModelEntityRules = new List<MetaModelBuilderRule>();
            this.ModelComplexTypeRules = new List<MetaModelBuilderRule>();
            this.ModelPropertyRules = new List<MetaModelBuilderRule>();
            this.ModelIndexRules = new List<MetaModelBuilderRule>();
            this.ModelIndexPropertyRules = new List<MetaModelBuilderRule>();
            this.ModelScalarTypeRules = new List<MetaModelBuilderRule>();
            this.ModelRelationRules = new List<MetaModelBuilderRule>();
        }
    }

    [JsonObject]
    public class MetaModelBuilderRule {
        [JsonIgnore]
        public bool Generated;

        //public string Kind { get; set; }
        [JsonProperty]
        public string SourceKey { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string ExternalName { get; set; }

        [JsonProperty]
        public string Result { get; set; }
    }
}
