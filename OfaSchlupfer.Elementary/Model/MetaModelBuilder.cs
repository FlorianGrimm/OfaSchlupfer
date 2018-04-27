namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    public class MetaModelBuilder {
        private readonly RulesForKind<ModelEntity> _RulesModelEntity;
        private readonly RulesForKind<ModelComplexType> _RulesModelComplexType;
        private readonly RulesForKind<ModelProperty> _RulesModelProperty;
        private readonly RulesForKind<ModelPrimaryKey> _RulesModelPrimaryKey;
        private readonly RulesForKind<ModelScalarType> _RulesModelScalarType;
        private readonly RulesForKind<ModelRelation> _RulesModelRelation;

        public MetaModelBuilder() {
            this._RulesModelEntity = new RulesForKind<ModelEntity>();
            this._RulesModelComplexType = new RulesForKind<ModelComplexType>();
            this._RulesModelProperty = new RulesForKind<ModelProperty>();
            this._RulesModelPrimaryKey = new RulesForKind<ModelPrimaryKey>();
            this._RulesModelScalarType = new RulesForKind<ModelScalarType>();
            this._RulesModelRelation = new RulesForKind<ModelRelation>();
        }

        public bool GenerateRules { get; set; }

        public void Initialize(MetaModelBuilderRules rules) {
            if (rules != null) {
                this._RulesModelEntity.Initialize(rules.ModelEntityRules);
                this._RulesModelComplexType.Initialize(rules.ModelComplexTypeRules);
                this._RulesModelProperty.Initialize(rules.ModelPropertyRules);
                this._RulesModelPrimaryKey.Initialize(rules.ModelPrimaryKeyRules);
                this._RulesModelScalarType.Initialize(rules.ModelScalarTypeRules);
                this._RulesModelRelation.Initialize(rules.ModelRelationRules);
            }
        }

        public MetaModelBuilderRules GetGeneratedRules() {
            var result = new MetaModelBuilderRules();
            result.ModelEntityRules.AddRange(this._RulesModelEntity.GeneratedRules.Values);
            result.ModelComplexTypeRules.AddRange(this._RulesModelComplexType.GeneratedRules.Values);
            result.ModelPropertyRules.AddRange(this._RulesModelProperty.GeneratedRules.Values);
            result.ModelPrimaryKeyRules.AddRange(this._RulesModelPrimaryKey.GeneratedRules.Values);
            result.ModelScalarTypeRules.AddRange(this._RulesModelScalarType.GeneratedRules.Values);
            return result;
        }

        public ModelEntity CreateModelEntity(
            string entityName,
            ModelEntityKind modelEntityKind,
            ModelErrors errors) {
            var result = new ModelEntity();
            result.Name = entityName;
            result.ExternalName = entityName;
            result.Kind = modelEntityKind;
            return this._RulesModelEntity.HandleRules(result.ExternalName, result, this.GenerateRules);
        }

        public ModelComplexType CreateModelComplexType(
            string complexTypeName,
            string complexTypeExternalName,
            ModelErrors errors) {
            var result = new ModelComplexType();
            result.Name = complexTypeName;
            result.ExternalName = complexTypeExternalName ?? complexTypeName;
            return this._RulesModelComplexType.HandleRules(result.ExternalName, result, this.GenerateRules);
        }

        public ModelProperty CreateModelProperty(
            string complexTypeName,
            string complexTypeExternalName,
            string propertyName,
            string propertyExternalName,
            ModelErrors errors
            ) {
            var result = new ModelProperty();
            result.Name = propertyName;
            result.ExternalName = propertyExternalName ?? propertyName;
            var key = (complexTypeExternalName ?? complexTypeName) + "." + result.ExternalName;
            return this._RulesModelProperty.HandleRules(key, result, this.GenerateRules);
        }

        public ModelPrimaryKey CreateModelPrimaryKey(
            string complexTypeName,
            string complexTypeExternalName,
            string propertyName,
            string propertyExternalName,
            //CsdlPropertyModel Property,
            ModelErrors errors
            ) {
            var result = new ModelPrimaryKey();
            result.Name = propertyName;
            result.ExternalName = propertyExternalName ?? propertyName;
            var key = (complexTypeExternalName ?? complexTypeName) + "." + result.ExternalName;
            return this._RulesModelPrimaryKey.HandleRules(key, result, this.GenerateRules);
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
                var result = new ModelScalarType();
                result.Name = scalarTypeName;
                result.MaxLength = maxLentgth;
                result.FixedLength = fixedLength;
                result.Nullable = nullable;
                result.Precision = precision;
                result.Scale = scale;
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
            var result =  new ModelRelation();
            result.Name = associationName;
            result.ExternalName = associationExternalName;
            result.MasterName = masterEntityName;
            result.MasterNavigationPropertyName = masterNavigationPropertyName;
            result.ForeignName = foreignEntityName;
            result.ForeignNavigationPropertyName = foreignNavigationPropertyName;
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
                var found = AllRules.GetValueOrDefault(key);
                if (found is null) {
                    if (generateRules) {
                        var name = result.Name;
                        var externalName = result.ExternalName ?? result.Name;
                        var json = JsonConvert.SerializeObject(result);
                        var rule = new MetaModelBuilderRule();
                        //rule.Kind = nameof(T);
                        rule.SourceKey = key;
                        rule.Name = name;
                        rule.ExternalName = externalName;
                        rule.Result = json;
                        rule.Generated = true;
                        AllRules.Add(key, rule);
                        GeneratedRules.Add(key, rule);
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
        public readonly List<MetaModelBuilderRule> ModelPrimaryKeyRules;
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelScalarTypeRules;
        [JsonProperty]
        public readonly List<MetaModelBuilderRule> ModelRelationRules;

        public MetaModelBuilderRules() {
            this.ModelEntityRules = new List<MetaModelBuilderRule>();
            this.ModelComplexTypeRules = new List<MetaModelBuilderRule>();
            this.ModelPropertyRules = new List<MetaModelBuilderRule>();
            this.ModelPrimaryKeyRules = new List<MetaModelBuilderRule>();
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
