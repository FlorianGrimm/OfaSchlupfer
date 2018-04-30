namespace OfaSchlupfer.ModelOData.Edm {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class CsdlReferentialConstraintV3Model : CsdlAnnotationalModel {
        private CsdlAssociationModel _Owner;

        // V3
        private CsdlReferentialConstraintPartnerV3Model _Principal;
        private CsdlReferentialConstraintPartnerV3Model _Dependent;

        public CsdlReferentialConstraintV3Model() {
        }

        [JsonProperty]
        public CsdlReferentialConstraintPartnerV3Model Principal {
            get { return this._Principal; }
            set {
                if (ReferenceEquals(this._Principal, value)) { return; }
                this._Principal = value;
                if (value != null) {
                    value.Owner = this;
                }
            }
        }

        [JsonProperty]
        public CsdlReferentialConstraintPartnerV3Model Dependent {
            get { return this._Dependent; }
            set {
                if (ReferenceEquals(this._Dependent, value)) { return; }
                this._Dependent = value;
                if (value != null) {
                    value.Owner = this;
                }
            }
        }

        [JsonIgnore]
        public CsdlAssociationModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref this._Owner, value);
        }

        public void ResolveNames(ModelErrors errors) {
            this.Principal?.ResolveNames(errors);
            this.Dependent?.ResolveNames(errors);
        }
    }
}