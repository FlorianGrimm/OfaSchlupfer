using OfaSchlupfer.Model;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlReferentialConstraintV3Model : CsdlAnnotationalModel {
        private CsdlAssociationModel _OwnerAssociationModel;

        // V3
        private CsdlReferentialConstraintPartnerV3Model _Principal;
        private CsdlReferentialConstraintPartnerV3Model _Dependent;

        public CsdlReferentialConstraintV3Model() {
        }

        public CsdlReferentialConstraintPartnerV3Model Principal {
            get { return this._Principal; }
            set {
                if (ReferenceEquals(this._Principal, value)) { return; }
                this._Principal = value;
                if (value != null) {
                    value.OwnerReferentialConstraintModel = this;
                }
            }
        }
        public CsdlReferentialConstraintPartnerV3Model Dependent {
            get { return this._Dependent; }
            set {
                if (ReferenceEquals(this._Dependent, value)) { return; }
                this._Dependent = value;
                if (value != null) {
                    value.OwnerReferentialConstraintModel = this;
                }
            }
        }

        public CsdlAssociationModel OwnerAssociationModel {
            get {
                return this._OwnerAssociationModel;
            }
            set {
                this._OwnerAssociationModel = value;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            this.Principal?.ResolveNames(errors);
            this.Dependent?.ResolveNames(errors);
        }
    }
}