namespace OfaSchlupfer.Model {
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using OfaSchlupfer.Freezable;

    [JsonObject()]
    public class ModelEntity : ModelType {
        [JsonIgnore]
        private ModelComplexType _EntityType;

        [JsonIgnore]
        private ModelEntityName _EntityTypeNáme;

        [JsonIgnore]
        private ModelEntityKind _Kind;

        [JsonProperty(Order = 5)]
        public readonly List<ModelConstraint> Constraints;

        public ModelEntity() {
            this.Constraints = new List<ModelConstraint>();
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
    }

    public enum ModelEntityKind {
        NotSet,
        Container,
        EntitySet
    }
}
