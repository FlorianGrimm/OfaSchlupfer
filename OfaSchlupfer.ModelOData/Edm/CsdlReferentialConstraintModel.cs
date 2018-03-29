namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlReferentialConstraintModel {
        private CsdlReferentialConstraintPartnerModel _Principal;
        private CsdlReferentialConstraintPartnerModel _Dependent;
        private CsdlSchemaModel _SchemaModel;

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
                        this.Principal.SchemaModel = value;
                    }
                    if ((object)this.Dependent != null) {
                        this.Dependent.SchemaModel = value;
                    }
                }
            }
        }

        public CsdlReferentialConstraintPartnerModel Principal {
            get { return this._Principal; }
            set {
                this._Principal = value;
                if (value != null) {
                    if ((object)this.SchemaModel != null) {
                        value.SchemaModel = this.SchemaModel;
                    }
                }
            }
        }
        public CsdlReferentialConstraintPartnerModel Dependent {
            get { return this._Dependent; }
            set {
                this._Dependent = value;
                if (value != null) {
                    if ((object)this.SchemaModel != null) {
                        value.SchemaModel = this.SchemaModel;
                    }
                }
            }
        }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            this.Principal?.ResolveNames(nameResolver);
            this.Dependent?.ResolveNames(nameResolver);
        }
    }
}