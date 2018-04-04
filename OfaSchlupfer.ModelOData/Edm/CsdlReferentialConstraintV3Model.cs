namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlReferentialConstraintV3Model : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;
        private CsdlAssociationModel _OwnerAssociationModel;

        // V3
        private CsdlReferentialConstraintPartnerV3Model _Principal;
        private CsdlReferentialConstraintPartnerV3Model _Dependent;

        public CsdlReferentialConstraintV3Model() {
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                if ((object)value != null) {
                    if ((object)this.Principal != null) {
                        this.Principal.OwnerReferentialConstraintModel = this;
                    }
                    if ((object)this.Dependent != null) {
                        this.Dependent.OwnerReferentialConstraintModel = this;
                    }
                }
            }
        }

        public CsdlReferentialConstraintPartnerV3Model Principal {
            get { return this._Principal; }
            set {
                if (ReferenceEquals(this._Principal, value)) { return; }
                this._Principal = value;
                this.SchemaModel = value?.SchemaModel;
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
                this.SchemaModel = value?.SchemaModel;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            this.Principal?.ResolveNames(errors);
            this.Dependent?.ResolveNames(errors);
        }
    }
}