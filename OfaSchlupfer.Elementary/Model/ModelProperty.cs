namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelProperty
        : ModelNamedOwnedElement<ModelComplexType> {
        [JsonIgnore]
        private ModelType _Type;

        public ModelProperty() { }
        
        [JsonProperty]
        public ModelType Type {
            get {
                return this._Type;
            }
            set {
                this.ThrowIfFrozen();
                this._Type = value;
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this.Type?.Freeze();
            }
            return result;
        }
    }
}
