namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelNamedElement
        : FreezeableObject
        , IMappingNamedObject<string> {
        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private string _ExternalName;

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

        [JsonProperty(Order = 2)]
        public string ExternalName {
            get {
                return this._ExternalName;
            }
            set {
                this.ThrowIfFrozen();
                this._ExternalName = value;
            }
        }

        public override string ToString() {
            return (this.Name == null) ? this.GetType().Name : this.Name.ToString();
        }

        string IMappingNamedObject<string>.GetName() => this._Name;
    }
}