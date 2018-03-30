namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlReferentialConstraintModel {
        private CsdlSchemaModel _SchemaModel;
        private CsdlAssociationModel _OwnerAssociationModel;

        private CsdlReferentialConstraintPartnerModel _Principal;
        private CsdlReferentialConstraintPartnerModel _Dependent;

        public CsdlReferentialConstraintModel() {
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            internal set {
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

        public CsdlReferentialConstraintPartnerModel Principal {
            get { return this._Principal; }
            set {
                if(ReferenceEquals(this._Principal, value)) { return; }
                this._Principal = value;
                this.SchemaModel = value?.SchemaModel;
                if (value != null) {
                    value.OwnerReferentialConstraintModel = this;
                }
            }
        }
        public CsdlReferentialConstraintPartnerModel Dependent {
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

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlAssociationModel associationModel, CsdlErrors errors) {
            this.Principal?.ResolveNames(edmxModel, schemaModel, associationModel, this, errors);
            this.Dependent?.ResolveNames(edmxModel, schemaModel, associationModel, this, errors);
        }
    }
}