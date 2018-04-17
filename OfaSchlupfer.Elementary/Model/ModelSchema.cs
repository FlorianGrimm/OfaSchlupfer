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
        public FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelComplexType> ComplexTypes => this._ComplexTypes;

        [JsonProperty(Order = 5)]
        public FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelEntity> Entities => this._Entities;

        [JsonProperty(Order = 6)]
        public FreezeableOwned2KeyedCollection<ModelSchema, string, string, ModelRelation> Relations => this._Relations;

        public ModelSchema() {
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
    }
}
