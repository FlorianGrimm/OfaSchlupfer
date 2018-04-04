using System;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlReferentialConstraintV4Model : CsdlAnnotationalModel {
        private CsdlNavigationPropertyModel _OwnerNavigationProperty;
        //V4
        private string _PropertyName;
        private CsdlPropertyModel _PropertyModel;
        private string _ReferencedPropertyName;
        private CsdlPropertyModel _ReferencedPropertyModel;

        public CsdlReferentialConstraintV4Model() {
        }

        public CsdlNavigationPropertyModel OwnerNavigationProperty {
            get {
                return this._OwnerNavigationProperty;
            }
            set {
                this._OwnerNavigationProperty = value;
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

        public CsdlPropertyModel Property {
            get {
                if (((object)this._PropertyName != null) && ((object)this._PropertyModel == null)) {
                    this.ResolveNamesProperty(CsdlErrors.GetIgnorance());
                }
                return this._PropertyModel;
            }
            set {
                if (ReferenceEquals(this._PropertyModel, value)) { return; }
                this._PropertyModel = value;
                this._PropertyName = value?.Name;
            }
        }

        public string ReferencedPropertyName {
            get {
                return this._ReferencedPropertyName;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._ReferencedPropertyName, value, StringComparison.Ordinal)) { return; }
                this._ReferencedPropertyName = value;
                this._ReferencedPropertyModel = null;
            }
        }

        public CsdlPropertyModel ReferencedProperty {
            get {
                if (((object)this._ReferencedPropertyName != null) && ((object)this._ReferencedPropertyModel == null)) {
                    this.ResolveNamesReferencedProperty(CsdlErrors.GetIgnorance());
                }
                return this._ReferencedPropertyModel;
            }
            set {
                if (ReferenceEquals(this._ReferencedPropertyModel, value)) { return; }
                this._ReferencedPropertyModel = value;
                this._ReferencedPropertyName = value?.Name;
            }
        }


        public void ResolveNames(CsdlErrors errors) {
            this.ResolveNamesProperty(errors);
            this.ResolveNamesReferencedProperty(errors);

        }

        public void ResolveNamesProperty(CsdlErrors errors) {
            if (this._PropertyModel == null && this._PropertyName != null) {
                if ((object)this._OwnerNavigationProperty != null) {
                    var ownerEntityTypeModel = this._OwnerNavigationProperty.OwnerEntityTypeModel;
                    var lstProperty = ownerEntityTypeModel.FindProperty(this._PropertyName);
                    if (lstProperty.Count == 1) {
                        this.Property = lstProperty[0];
                    } else if (lstProperty.Count == 0) {
                        errors.AddError($"Property '{this._PropertyName}' not found in {ownerEntityTypeModel.FullName}.");
                    } else {
                        errors.AddError($"Property '{this._PropertyName}' found #{lstProperty.Count} times in {ownerEntityTypeModel.FullName}.");
                    }
                }
            }
        }

        public void ResolveNamesReferencedProperty(CsdlErrors errors) {
            if (this._ReferencedPropertyModel == null && this._ReferencedPropertyName != null) {
                if ((object)this._OwnerNavigationProperty != null) {
                    var entityTypeModel = this._OwnerNavigationProperty.TypeModel?.GetEntityTypeModel();
                    if (entityTypeModel != null) {
                        var lstReferencedProperty = entityTypeModel.FindProperty(this._ReferencedPropertyName);
                        if (lstReferencedProperty.Count == 1) {
                            this.ReferencedProperty = lstReferencedProperty[0];
                        } else if (lstReferencedProperty.Count == 0) {
                            errors.AddError($"ReferencedProperty '{this._ReferencedPropertyName}' not found in {entityTypeModel.FullName}.");
                        } else {
                            errors.AddError($"ReferencedProperty '{this._ReferencedPropertyName}' found #{lstReferencedProperty.Count} times in {entityTypeModel.FullName}.");
                        }
                    }
                }
            }
        }
    }
}