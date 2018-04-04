namespace OfaSchlupfer.ModelOData.Edm {
    using System;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPropertyRefModel : CsdlAnnotationalModel {
        private CsdlReferentialConstraintPartnerV3Model _OwnerReferentialConstraintPartnerModel;
        private string _PropertyName;
        private CsdlPropertyModel _PropertyModel;

        public CsdlPropertyRefModel() {
        }

        public CsdlReferentialConstraintPartnerV3Model OwnerReferentialConstraintPartnerModel {
            get {
                return this._OwnerReferentialConstraintPartnerModel;
            }
            set {
                this._OwnerReferentialConstraintPartnerModel = value;
            }
        }
        public string PropertyName {
            get {
                return this._PropertyName;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._PropertyName, value, StringComparison.Ordinal)) { return; }
                this._PropertyName = value;
                this._PropertyModel = null;
            }
        }

        public CsdlPropertyModel PropertyModel {
            get {
                if (((object)this._PropertyName != null) && ((object)this._PropertyModel == null)) {
                    if ((object)this._OwnerReferentialConstraintPartnerModel != null) {
                        this.ResolveNames(CsdlErrors.GetIgnorance());
                    }
                }
                return this._PropertyModel;
            }
            set {
                if (ReferenceEquals(this._PropertyModel, value)) { return; }
                this._PropertyModel = value;
                this._PropertyName = value?.Name;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            if (this._PropertyModel == null && this._PropertyName != null) {
                var referentialConstraintPartnerModel = this.OwnerReferentialConstraintPartnerModel;
                var roleEnd = referentialConstraintPartnerModel?.RoleEnd;
                var roleTypeModel = roleEnd?.TypeModel;
                if (roleTypeModel != null) {
                    var lstProperty = roleTypeModel.FindProperty(this._PropertyName);
                    if (lstProperty.Count == 1) {
                        this.PropertyModel = lstProperty[0];
                    } else if (lstProperty.Count == 0) {
                        errors.AddError($"Property '{this.PropertyName}' not found in {roleTypeModel.FullName}.");
                    } else {
                        errors.AddError($"Property '{this.PropertyName}' found #{lstProperty.Count} times in {roleTypeModel.FullName}.");
                    }
                }
            }
        }
    }
}