namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
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
        : FreezeableObject
        , IMappingNamedObject<ModelEntityName> {
        [JsonIgnore]
        private ModelEntityName _RootEntityName;

        [JsonIgnore]
        internal ModelEntityName _Name;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<ModelSchema, ModelComplexType> _ComplexTypes;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<ModelSchema, ModelEntity> _Entities;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<ModelSchema, ModelRelation> _Relations;

        [JsonProperty(Order = 2)]
        public ModelEntityName RootEntityName {
            get {
                return this._RootEntityName;
            }
            set {
                this.ThrowIfFrozen();
                this._RootEntityName = value;
            }
        }


        [JsonProperty(Order = 3)]
        public IList<ModelComplexType> ComplexTypes => this._ComplexTypes;

        [JsonProperty(Order = 4)]
        public IList<ModelEntity> Entities => this._Entities;

        [JsonProperty(Order = 5)]
        public IList<ModelRelation> Relations => this._Relations;

        public ModelSchema() {
            this._ComplexTypes = new FreezeableOwnedCollection<ModelSchema, ModelComplexType>(this, (owner, item) => { item.Owner = owner; });
            this._Entities = new FreezeableOwnedCollection<ModelSchema, ModelEntity>(this, (owner, item) => { item.Owner = owner; });
            this._Relations = new FreezeableOwnedCollection<ModelSchema, ModelRelation>(this, (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public ModelEntityName Name => this._Name;

        public void PostDeserialize() {
        }

        public ModelEntityName GetName() => this._Name;

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._ComplexTypes.Freeze();
                this._Entities.Freeze();
                this._Relations.Freeze();
            }
            return result;
        }

        public class Current {
            public readonly ModelSchema ModelSchema;
            public readonly Dictionary<ModelEntityName, ModelEntity> EntityByName;
            public readonly Dictionary<string, ModelRelation> RelationByName;
            public readonly Dictionary<ModelEntityName, ModelComplexType> ComplexTypes;

            public Current(ModelSchema modelSchema, bool build) {
                this.ModelSchema = modelSchema;
                var stringComparer = ModelUtility.Instance.StringComparer;
                var nameEqualityComparer = ModelUtility.Instance.ModelEntityNameEqualityComparer;
                if (build) {
                    this.ComplexTypes = modelSchema.ComplexTypes.ToDictionary(_ => _.Name, nameEqualityComparer);
                    this.EntityByName = modelSchema.Entities.ToDictionary(_ => _.Name, nameEqualityComparer);
                    this.RelationByName = modelSchema.Relations.ToDictionary(_ => _.Name, stringComparer);
                } else {
                    this.ComplexTypes = new Dictionary<ModelEntityName, ModelComplexType>(nameEqualityComparer);
                    this.EntityByName = new Dictionary<ModelEntityName, ModelEntity>(nameEqualityComparer);
                    this.RelationByName = new Dictionary<string, ModelRelation>(stringComparer);
                }
            }
        }
    }
}
