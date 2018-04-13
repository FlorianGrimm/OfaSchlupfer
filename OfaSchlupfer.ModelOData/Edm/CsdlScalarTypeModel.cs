namespace OfaSchlupfer.ModelOData.Edm {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class CsdlScalarTypeModel
        : FreezeableObject
        , ICsdlTypeModel {
        [JsonIgnore]
        private CsdlSchemaModel _Owner;
        [JsonIgnore]
        private string _Namespace;
        [JsonIgnore]
        private string _Name;

        public CsdlScalarTypeModel(string @namespace, string name) {
            this.Namespace = @namespace;
            this.Name = name;
        }

        [JsonIgnore]
        public CsdlSchemaModel Owner {
            get { return this._Owner; }
            internal set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }

        [JsonProperty]
        public string Namespace {
            get {
                return this._Namespace;
            }
            set {
                this.ThrowIfFrozen();
                this._Namespace = value;
            }
        }


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

        public string FullName => this.Namespace + "." + this.Name;
        CsdlEntityTypeModel ICsdlTypeModel.GetEntityTypeModel() => null;
    }
}