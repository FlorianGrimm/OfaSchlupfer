namespace OfaSchlupfer.ModelOData.Edm {
    using System;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPropertyRefModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;
        private CsdlReferentialConstraintPartnerModel _OwnerReferentialConstraintPartnerModel;
        private string _Name;
        private CsdlPropertyModel _Property;

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
                if (!ReferenceEquals(value, this._OwnerReferentialConstraintPartnerModel?.SchemaModel)) {
                    this._OwnerReferentialConstraintPartnerModel = null;
                }
            }
        }

        public CsdlReferentialConstraintPartnerModel OwnerReferentialConstraintPartnerModel {
            get {
                return this._OwnerReferentialConstraintPartnerModel;
            }
            set {
                this._OwnerReferentialConstraintPartnerModel = value;
                this.SchemaModel = value?.SchemaModel;
            }
        }
        public string Name {
            get {
                return this._Name;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._Name, value, StringComparison.Ordinal)) { return; }
                this._Name = value;
                this._Property = null;
            }
        }

        public CsdlPropertyModel Property {
            get {
                if (((object)this._Name != null) && ((object)this._Property == null)) {
                    if ((object)this._OwnerReferentialConstraintPartnerModel != null) {
                        this.ResolveNames(CsdlErrors.GetIgnorance());
                    }
                }
                return this._Property;
            }
            set {
                if (ReferenceEquals(this._Property, value)) { return; }
                this._Property = value;
                this._Name = value?.Name;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            if (this._Property == null && this._Name != null) {
                var referentialConstraintPartnerModel = this.OwnerReferentialConstraintPartnerModel;
                var roleEnd = referentialConstraintPartnerModel?.RoleEnd;
                var roleTypeModel = roleEnd?.TypeModel;
                if (roleTypeModel != null) {
                    var lstProperty = roleTypeModel.FindProperty(this._Name);
                    if (lstProperty.Count == 1) {
                        this.Property = lstProperty[0];
                    } else if (lstProperty.Count == 0) {
                        errors.AddError($"Property '{this.Name}' not found in {roleTypeModel.FullName}.");
                    } else {
                        errors.AddError($"Property '{this.Name}' found #{lstProperty.Count} times in {roleTypeModel.FullName}.");
                    }
                }
            }
        }
    }
}