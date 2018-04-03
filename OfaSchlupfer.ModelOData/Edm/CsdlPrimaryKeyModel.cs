namespace OfaSchlupfer.ModelOData.Edm {
    using System;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPrimaryKeyModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityTypeModel _OwnerEntityTypeModel;
        private string _Name;
        private CsdlPropertyModel _Property;

        public CsdlPrimaryKeyModel() {
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

        public string Name {
            get {
                if (this._Property != null) {
                    return this._Property.Name;
                } else {
                    return this._Name;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._Name, value, StringComparison.OrdinalIgnoreCase)) { return; }
                this._Name = value;
                if ((object)this._Property != null) {
                    if (string.Equals(this._Name, this.Property.Name, StringComparison.OrdinalIgnoreCase)) {
                        this._Property = null;
                    }
                }
            }
        }

        public CsdlPropertyModel Property {
            get {
                if (((object)this._Name != null) && ((object)this._Property == null)) {
                    if ((object)this._OwnerEntityTypeModel != null) {
                        this.ResolveNames(CsdlErrors.GetIgnorance());
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


        public void ResolveNames(CsdlErrors errors) {
            if ((object)this._OwnerEntityTypeModel != null) {
                var lstProperty = this._OwnerEntityTypeModel.FindProperty(this.Name);
                if (lstProperty.Count == 1) {
                    this.Property = lstProperty[0];
                } else if (lstProperty.Count == 0) {
                    errors.AddError("TODO");
                } else {
                    errors.AddError("TODO");
                }
            }
        }
    }
}