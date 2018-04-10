namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelScalarType
        : ModelType {
        [JsonIgnore]
        private bool _IsNullable;

        public ModelScalarType() {
            this.IsNullable = true;
        }

        [JsonProperty(Order = 2)]
        public bool IsNullable {
            get {
                return this._IsNullable;
            }
            set {
                this.ThrowIfFrozen();
                this._IsNullable = value;
            }
        }
    }
}
