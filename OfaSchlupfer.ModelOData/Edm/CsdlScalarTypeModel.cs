namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class CsdlScalarTypeModel
        : FreezableObject
        , ICsdlTypeModel {
        [JsonIgnore]
        private CsdlSchemaModel _Owner;

        [JsonIgnore]
        private string _Namespace;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private readonly ICsdlScalarTypeModelTarget[] Targets;

        public CsdlScalarTypeModel(string @namespace, string name, params ICsdlScalarTypeModelTarget[] targets) {
            this.Namespace = @namespace;
            this.Name = name;
            this.Targets = targets;
        }

        [JsonIgnore]
        public CsdlSchemaModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref this._Owner, value);
        }

        [JsonProperty]
        public string Namespace {
            get {
                return this._Namespace;
            }
            set {
                this.ThrowIfFrozen();
                this._Namespace = value;
            }
        }


        [JsonProperty]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        public string FullName => this.Namespace + "." + this.Name;
        CsdlEntityTypeModel ICsdlTypeModel.GetEntityTypeModel() => null;

        public ModelScalarType SuggestType(
                IModelScalarTypeFacade modelScalarTypeFacade,
                MetaModelBuilder metaModelBuilder
            ) {
            var results = new List<ModelScalarType>();
            foreach (var target in this.Targets) {
                var modelScalarType = target.SuggestType(modelScalarTypeFacade);
                results.Add(modelScalarType);
            }
            if (results.Count > 1) {
                var suggestType = metaModelBuilder.CreateModelScalarType(modelScalarTypeFacade, results);
                return suggestType ?? results[0];
            }
            if (results.Count > 0) {
                return results[0];
            } else {
                return null;
            }
        }
    }

    public interface ICsdlScalarTypeModelTarget {
        ModelScalarType SuggestType(IModelScalarTypeFacade modelScalarTypeFacade);
    }

    public sealed class CsdlScalarTypeModelTarget
        : ICsdlScalarTypeModelTarget {
        public readonly Type Type;

        public CsdlScalarTypeModelTarget(Type type) {
            this.Type = type;
        }

        public ModelScalarType SuggestType(IModelScalarTypeFacade modelScalarTypeFacade) {
            var result = new ModelScalarType();
            if (modelScalarTypeFacade.Nullable.GetValueOrDefault(true)) {
                if (this.Type.IsValueType) {
                    result.Type = typeof(Nullable<>).MakeGenericType(new Type[] { this.Type });
                } else {
                    result.Type = this.Type;
                }
            } else {
                result.Type = this.Type;
            }
            result.Nullable = modelScalarTypeFacade.Nullable;
            result.MaxLength = modelScalarTypeFacade.MaxLength;
            result.FixedLength = modelScalarTypeFacade.FixedLength;
            result.Precision = modelScalarTypeFacade.Precision;
            result.Scale = modelScalarTypeFacade.Scale;
            result.Unicode = modelScalarTypeFacade.Unicode;
            return result;
        }
    }
}