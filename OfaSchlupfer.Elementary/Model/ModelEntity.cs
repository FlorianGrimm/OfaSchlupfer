namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject()]
    public class ModelEntity : ModelType {
        private ModelComplexType _EntityType;
        private ModelEntityName _EntityTypeNáme;

        [JsonProperty(Order = 5)]
        public readonly List<ModelConstraint> Constraints;

        public ModelEntity() {
            this.Constraints = new List<ModelConstraint>();
        }

        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ModelEntityKind Kind { get; set; }

        [JsonProperty(Order = 3)]
        public ModelEntityName EntityTypeNáme {
            get {
                return this._EntityTypeNáme;
            }
            set {
                this._EntityTypeNáme = value;
            }
        }

        [JsonIgnore]
        public ModelComplexType EntityType {
            get {
                return this._EntityType;
            }
            set {
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
