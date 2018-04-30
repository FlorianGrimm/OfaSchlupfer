namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlPrimaryKeyModel : CsdlAnnotationalModel {
        private CsdlEntityTypeModel _Owner;
        private string _Name;
        private CsdlPropertyModel _Property;

        public CsdlPrimaryKeyModel() {
        }

        [JsonIgnore]
        public CsdlEntityTypeModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref this._Owner, value);
        }

        [JsonProperty]
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

        [JsonIgnore]
        public CsdlPropertyModel Property {
            get {
                if (((object)this._Name != null) && ((object)this._Property == null)) {
                    if ((object)this._Owner != null) {
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
                if ((object)this._Owner != null) {
                    var lstProperty = this._Owner.FindProperty(this.Name);
                    if (lstProperty.Count == 1) {
                        this.Property = lstProperty[0];
                    } else if (lstProperty.Count == 0) {
                        errors.AddErrorOrThrow($"Property '{this.Name}' not found in {this.Owner.FullName}.", this.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"Property '{this.Name}' found #{lstProperty.Count} times in {this.Owner.FullName}.", this.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
    }
}