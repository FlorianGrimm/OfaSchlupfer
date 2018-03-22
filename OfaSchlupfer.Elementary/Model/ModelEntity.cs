namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject(ItemIsReference = true)]
    public class ModelEntity : ModelType {
        private ModelTableType _TableType;
        private ModelEntityName _TableTypeNáme;

        [JsonProperty(Order = 5)]
        public readonly List<ModelConstraint> Constraints;

        public ModelEntity() {
            this.Constraints = new List<ModelConstraint>();
        }

        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ModelEntityKind Kind { get; set; }

        [JsonProperty(Order = 3)]
        public ModelEntityName TableTypeNáme {
            get {
                return this._TableTypeNáme;
            }
            set {
                this._TableTypeNáme = value;
            }
        }
        [JsonProperty(Order = 4, IsReference = true)]
        public ModelTableType TableType {
            get {
                return this._TableType;
            }
            set {
                this._TableType = value;
                if (value != null) {
                    this._TableTypeNáme = value.Name;
                }
            }
        }
    }

    public enum ModelEntityKind {
        Container,
        EntitySet
    }
}
