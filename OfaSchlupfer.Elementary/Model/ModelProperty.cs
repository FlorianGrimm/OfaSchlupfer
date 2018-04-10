namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelProperty
        : FreezeableObject
        , IMappingNamedObject<string> {

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private ModelType _Type;

        public ModelProperty() { }

        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        public ModelType Type {
            get {
                return this._Type;
            }
            set {
                this.ThrowIfFrozen();
                this._Type = value;
            }
        }

        public string GetName() => this._Name;
    }
}
