namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelNamedElement
        : FreezeableObject
        , IMappingNamedObject<string> {
        [JsonIgnore]
        protected string _Name;

        [JsonIgnore]
        protected string _ExternalName;

        public ModelNamedElement() { }

        [JsonProperty(Order = 1, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Name {
            get => this._Name;
            set => this.SetStringProperty(ref this._Name, value);
        }

        [JsonProperty(Order = 2, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string ExternalName {
            get => this._ExternalName;
            set => this.SetStringProperty(ref this._ExternalName, value);
        }

        public override string ToString() {
            return (this.Name == null) ? this.GetType().Name : this.Name.ToString();
        }

        string IMappingNamedObject<string>.GetName() => this._Name;
    }
}