namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPrimaryKeyModel : CsdlAnnotationalModel {
        private CsdlEntityTypeModel _OwnerEntityTypeModel;
        private string _Name;
        private CsdlPropertyModel _Property;

        public CsdlPrimaryKeyModel() {
        }

        public CsdlEntityTypeModel OwnerEntityTypeModel {
            get {
                return this._OwnerEntityTypeModel;
            }
            set {
                this._OwnerEntityTypeModel = value;
            }
        }

        public string Name {
            get {
                var property1 = this._Property;
                if (property1 != null) {
                    return property1.Name;
                } else {
                    return this._Name;
                }
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
                    if ((object)this._OwnerEntityTypeModel != null) {
                        this.ResolveNames(ModelErrors.GetIgnorance());
                    }
                }
                return this._Property;
            }
            set {
                if (ReferenceEquals(this._Property, value)) { return; }
                this._Property = value;
                this._Name = null;
            }
        }


        public void ResolveNames(ModelErrors errors) {
            if (this._Property == null && this._Name != null) {
                if ((object)this._OwnerEntityTypeModel != null) {
                    var lstProperty = this._OwnerEntityTypeModel.FindProperty(this.Name);
                    if (lstProperty.Count == 1) {
                        this.Property = lstProperty[0];
                    } else if (lstProperty.Count == 0) {
                        errors.AddErrorXmlParsing($"Property '{this.Name}' not found in {this.OwnerEntityTypeModel.FullName}.");
                    } else {
                        errors.AddErrorXmlParsing($"Property '{this.Name}' found #{lstProperty.Count} times in {this.OwnerEntityTypeModel.FullName}.");
                    }
                }
            }
        }
    }
}