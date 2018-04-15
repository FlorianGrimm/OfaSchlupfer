namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelNamedElement
        : FreezeableObject
        , IMappingNamedObject<string> {
        private string _Name;

        public ModelNamedElement() { }

        [JsonProperty(Order = 1)]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        public override string ToString() {
            return (this.Name == null) ? this.GetType().Name : this.Name.ToString();
        }

        string IMappingNamedObject<string>.GetName() => this._Name;
    }
}