namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPropertyRefModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;
        private CsdlReferentialConstraintPartnerModel _OwnerReferentialConstraintPartnerModel;
        private CsdlEntityTypeModel _OwnerEntityTypeModel;
        public string Name;

        public CsdlPropertyRefModel() {
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
                if (!ReferenceEquals(value, this._OwnerEntityTypeModel?.SchemaModel)) {
                    this._OwnerEntityTypeModel = null;
                }
                if (!ReferenceEquals(value, this._OwnerReferentialConstraintPartnerModel?.SchemaModel)) {
                    this._OwnerReferentialConstraintPartnerModel = null;
                }
            }
        }

        public CsdlEntityTypeModel OwnerEntityTypeModel {
            get {
                return this._OwnerEntityTypeModel;
            }
            set {
                this._OwnerEntityTypeModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public CsdlReferentialConstraintPartnerModel OwnerReferentialConstraintPartnerModel {
            get {
                return this._OwnerReferentialConstraintPartnerModel;
            }
            set {
                this._OwnerReferentialConstraintPartnerModel=value;
                this.SchemaModel = value?.SchemaModel;
            }
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlAssociationModel associationModel, CsdlReferentialConstraintPartnerModel csdlReferentialConstraintPartnerModel, CsdlReferentialConstraintModel referentialConstraintModel, CsdlErrors errors) {
            // TODO: resolve this.Name
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlEntityTypeModel entityTypeModel, CsdlErrors errors) {
        }
    }
}