namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlPropertyRefModel : CsdlAnnotationalModel {
        private CsdlReferentialConstraintPartnerV3Model _Owner;
        private string _PropertyName;
        private CsdlPropertyModel _PropertyModel;

        public CsdlPropertyRefModel() {
        }

        [JsonIgnore]
        public CsdlReferentialConstraintPartnerV3Model Owner {
            get {
                return this._Owner;
            }
            internal set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }

        [JsonProperty]
        public string PropertyName {
            get {
                return this._PropertyName;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._PropertyName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._PropertyName = value;
                this._PropertyModel = null;
            }
        }

        [JsonIgnore]
        public CsdlPropertyModel PropertyModel {
            get {
                if (((object)this._PropertyName != null) && ((object)this._PropertyModel == null)) {
                    if ((object)this._Owner != null) {
                        this.ResolveNames(ModelErrors.GetIgnorance());
                    }
                }
                return this._PropertyModel;
            }
            set {
                if (ReferenceEquals(this._PropertyModel, value)) { return; }
                this.ThrowIfFrozen();
                this._PropertyModel = value;
                this._PropertyName = value?.Name;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            if (this._PropertyModel == null && this._PropertyName != null) {
                var referentialConstraintPartnerModel = this.Owner;
                var roleEnd = referentialConstraintPartnerModel?.RoleEnd;
                var roleTypeModel = roleEnd?.TypeModel;
                if (roleTypeModel != null) {
                    var lstProperty = roleTypeModel.FindProperty(this._PropertyName);
                    if (lstProperty.Count == 1) {
                        this.PropertyModel = lstProperty[0];
                    } else if (lstProperty.Count == 0) {
                        errors.AddErrorOrThrow($"Property '{this.PropertyName}' not found in {roleTypeModel.FullName}.", this._Owner?.RoleName, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"Property '{this.PropertyName}' found #{lstProperty.Count} times in {roleTypeModel.FullName}.", this._Owner.RoleName, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
    }
}