namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using OfaSchlupfer.Model;

    public class CsdlNavigationPropertyBindingModel : CsdlAnnotationalModel {
        private string _TargetName;
        private CsdlNavigationPropertyModel _PathName;

        public CsdlNavigationPropertyBindingModel() {
        }
        public CsdlEntitySetModel OwnerEntitySetModel { get; set; }

        public string TargetName { get; set; }

        public string PathName {
            get {
                if (this._PathName != null) {
                    return this._PathName.Name;
                } else {
                    return this._TargetName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._TargetName, value, StringComparison.Ordinal)) { return; }
                this._TargetName = value;
                this._PathName = null;
            }
        }

        public CsdlNavigationPropertyModel PathModel {
            get {
                if (this._PathName == null) {
                    this.ResolveNames(ModelErrors.GetIgnorance());
                }
                return this._PathName;
            }
            set {
                this._PathName = value;
                this._TargetName = null;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            if ((this._PathName == null) && (this._TargetName != null)) {
                var entitySetModel = this.OwnerEntitySetModel;
                var entityTypeModel = entitySetModel?.EntityTypeModel;
                if (entityTypeModel != null) {
                    var lstNavProperty = entityTypeModel.FindNavigationProperty(this.PathName);
                    if (lstNavProperty.Count == 1) {
                        this.PathModel = lstNavProperty[0];
                    } else if (lstNavProperty.Count == 0) {
                        errors.AddErrorXmlParsing($"Property {this._TargetName} in {entityTypeModel.FullName} not found.");
                    } else {
                        errors.AddErrorXmlParsing($"Property {this._TargetName} in {entityTypeModel.FullName} found #{lstNavProperty.Count} times.");
                    }
                }
            }
        }
    }
}