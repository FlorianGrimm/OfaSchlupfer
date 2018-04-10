namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelNamedElement
        : FreezeableObject
        , IMappingNamedObject<ModelEntityName> {
        private ModelEntityName _Name;

        public ModelNamedElement() { }

        [JsonProperty(Order = 1)]
        public ModelEntityName Name {
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

        ModelEntityName IMappingNamedObject<ModelEntityName>.GetName() => this._Name;
    }
}