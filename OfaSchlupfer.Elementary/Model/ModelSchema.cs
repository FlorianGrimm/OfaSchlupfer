namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The schema, classes, or entity projection
    /// </summary>
    [JsonObject]
    public class ModelSchema
        : ModelNamedOwnedElement<ModelRepository> {
        [JsonIgnore]
        private string _RootEntityName;

        [JsonIgnore]
        private readonly FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelScalarType> _ScalarTypes;

        [JsonIgnore]
        private readonly FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelComplexType> _ComplexTypes;

        [JsonIgnore]
        private readonly FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelEntity> _Entities;

        [JsonIgnore]
        private readonly FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelRelation> _Relations;

        [JsonProperty(Order = 3)]
        public string RootEntityName {
            get {
                return this._RootEntityName;
            }
            set {
                this.ThrowIfFrozen();
                this._RootEntityName = value;
            }
        }


        [JsonProperty(Order = 4)]
        public FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelScalarType> ScalarTypes => this._ScalarTypes;

        [JsonProperty(Order = 5)]
        public FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelComplexType> ComplexTypes => this._ComplexTypes;

        [JsonProperty(Order = 6)]
        public FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelEntity> Entities => this._Entities;

        [JsonProperty(Order = 7)]
        public FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelRelation> Relations => this._Relations;

        public ModelSchema() {
            this._ScalarTypes = new FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelScalarType>(
                this,
                (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (item) => item.ExternalName,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
            this._ComplexTypes = new FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelComplexType>(
                this,
                (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (item) => item.ExternalName,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
            this._Entities = new FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelEntity>(
                this,
                (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (item) => item.ExternalName,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
            this._Relations = new FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelRelation>(this,
                (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (item) => item.ExternalName,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public override ModelRepository Owner {
            get => this._Owner;
            set => this.SetOwnerAndProperty(ref _Owner, value, (owner)=>owner.ModelSchema, (owner, newValue) => owner.ModelSchema = newValue);
        }

        public void PostDeserialize() {
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._ComplexTypes.Freeze();
                this._Entities.Freeze();
                this._Relations.Freeze();
            }
            return result;
        }

        public List<ModelEntity> FindEntity(string name) => this._Entities.FindByKey(name);

        public List<ModelComplexType> FindComplexType(string name) => this._ComplexTypes.FindByKey(name);

        public List<ModelRelation> FindRelation(string name) => this._Relations.FindByKey(name);

        public EntitySchema GetEntitySchema() {
            var result = new EntitySchema(null);
            foreach (var complexType in this.ComplexTypes) {
                var metaEntity = complexType.GetMetaEntity();
                if (!(metaEntity.EntityTypeName is null)) {
                    result.Add(null, metaEntity);
                }
            }
            return result;
        }

        public ModelEntity CreateEntity(string name) {
            var result = new ModelEntity();
            result.Kind = ModelEntityKind.EntitySet;
            result.Name = name;
            this.Entities.Add(result);
            return result;
        }

        public ModelComplexType CreateComplexType(string name) {
            var result = new ModelComplexType();
            result.Name = name;
            this.ComplexTypes.Add(result);
            return result;
        }
    }
}
