namespace OfaSchlupfer.Model {
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using OfaSchlupfer.Freezable;

    [JsonObject()]
    public class ModelEntity
        : ModelType {
        [JsonIgnore]
        private ModelSchema _Owner;

        [JsonIgnore]
        private ModelComplexType _EntityType;

        [JsonIgnore]
        private ModelEntityName _EntityTypeNáme;

        [JsonIgnore]
        private ModelEntityKind _Kind;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<ModelEntity, ModelConstraint> _Constraints;

        [JsonProperty(Order = 5)]
        public IList<ModelConstraint> Constraints => this._Constraints;

        public ModelEntity() {
            this._Constraints = new FreezeableOwnedCollection<ModelEntity, ModelConstraint>(this, (owner, item) => { item.Owner = owner; });
        }

        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ModelEntityKind Kind {
            get {
                return this._Kind;
            }
            set {
                this.ThrowIfFrozen();
                this._Kind = value;
            }
        }

        [JsonProperty(Order = 3)]
        public ModelEntityName EntityTypeNáme {
            get {
                return this._EntityTypeNáme;
            }
            set {
                this.ThrowIfFrozen();
                this._EntityTypeNáme = value;
            }
        }

        [JsonIgnore]
        public ModelComplexType EntityType {
            get {
                return this._EntityType;
            }
            set {
                this.ThrowIfFrozen();
                this._EntityType = value;
                if (value != null) {
                    this._EntityTypeNáme = value.Name;
                }
            }
        }

        [JsonIgnore]
        public ModelSchema Owner {
            get {
                return this._Owner;
            }
            set {
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Constraints.Freeze();
                this.EntityTypeNáme?.Freeze();
                this.EntityType?.Freeze();
            }
            return result;
        }
    }

    public enum ModelEntityKind {
        NotSet,
        Container,
        EntitySet
    }
}
