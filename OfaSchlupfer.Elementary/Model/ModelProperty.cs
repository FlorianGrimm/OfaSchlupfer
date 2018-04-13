namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelProperty
        : FreezeableObject
        , IMappingNamedObject<string> {

        [JsonIgnore]
        private ModelComplexType _Owner;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private ModelType _Type;

        public ModelProperty() { }

        [JsonProperty]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

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

        [JsonIgnore]
        public ModelComplexType Owner {
            get {
                return this._Owner;
            }
            set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }


        public string GetName() => this._Name;

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this.Type?.Freeze();
            }
            return result;
        }
    }
}
