namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlReferentialConstraintPartnerModel : CsdlAnnotationalModel {
        public readonly CsdlCollection<CsdlPropertyRefModel> PropertyRef;
        private CsdlSchemaModel _SchemaModel;
        private CsdlReferentialConstraintModel _OwnerReferentialConstraintModel;

        public string Role;

        public CsdlReferentialConstraintPartnerModel() {
            this.PropertyRef = new CsdlCollection<CsdlPropertyRefModel>((item) => { item.OwnerReferentialConstraintPartnerModel = this; });
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
                if (!ReferenceEquals(value, this._OwnerReferentialConstraintModel?.SchemaModel)) {
                    this._OwnerReferentialConstraintModel = null;
                }
                if ((object)value != null) {
                    this.PropertyRef.Broadcast();
                }
            }
        }

        public CsdlReferentialConstraintModel OwnerReferentialConstraintModel {
            get {
                return this._OwnerReferentialConstraintModel;
            }
            set {
                if (ReferenceEquals(this._OwnerReferentialConstraintModel, value)) { return; }
                this._OwnerReferentialConstraintModel = value;
                this.SchemaModel = value?.SchemaModel;
            }
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlAssociationModel associationModel, CsdlReferentialConstraintModel referentialConstraintModel, CsdlErrors errors) {
            foreach (var propertyRef in this.PropertyRef) {
                propertyRef.ResolveNames(edmxModel, schemaModel, associationModel, this, referentialConstraintModel, errors);
            }
        }
    }
}