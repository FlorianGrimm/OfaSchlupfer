namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Role}")]
    [JsonObject]
    public class CsdlReferentialConstraintPartnerV3Model : CsdlAnnotationalModel {
        private readonly FreezeableOwnedKeyedCollection<CsdlReferentialConstraintPartnerV3Model, string, CsdlPropertyRefModel> _PropertyRef;
        private CsdlReferentialConstraintV3Model _Owner;
        private string _RoleName;
        private CsdlAssociationEndModel _RoleEnd;

        public CsdlReferentialConstraintPartnerV3Model() {
            this._PropertyRef = new FreezeableOwnedKeyedCollection<CsdlReferentialConstraintPartnerV3Model, string, CsdlPropertyRefModel>(
                this,
                (item) => item.PropertyName,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public CsdlReferentialConstraintV3Model Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref _Owner, value);
        }

        [JsonProperty]
        public string RoleName {
            get {
                return this._RoleName;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._RoleName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._RoleName = value;
                this._RoleEnd = null;
            }
        }

        [JsonIgnore]
        public CsdlAssociationEndModel RoleEnd {
            get {
                if (this._RoleEnd == null) {
                    this.ResolveNames(ModelErrors.GetIgnorance());
                }
                return this._RoleEnd;
            }
            set {
                this.ThrowIfFrozen();
                this._RoleEnd = value;
                this._RoleName = null;
            }
        }

        [JsonProperty]
        public FreezeableOwnedKeyedCollection<CsdlReferentialConstraintPartnerV3Model, string, CsdlPropertyRefModel> PropertyRef => this._PropertyRef;

        public List<CsdlPropertyRefModel> FindPropertyRef(string propertyName) => this._PropertyRef.FindByKey(propertyName);

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNameRoleEnd(errors);
            foreach (var propertyRef in this.PropertyRef) {
                propertyRef.ResolveNames(errors);
            }
        }

        public void ResolveNameRoleEnd(ModelErrors errors) {
            if (this._RoleEnd == null && this._RoleName != null) {
                var referentialConstraintModel = this.Owner;
                var associationModel = referentialConstraintModel.Owner;
                if (associationModel != null) {
                    var lstEnd = associationModel.FindAssociationEnd(this._RoleName);
                    if (lstEnd.Count == 1) {
                        this._RoleEnd = lstEnd[0];
                        this._RoleName = null;
                    } else if (lstEnd.Count == 0) {
                        errors.AddErrorOrThrow($"ToRole {this._RoleName} not found in {associationModel.FullName}.", associationModel.FullName, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"ToRole {this._RoleName}  found #{lstEnd.Count} times in {associationModel.FullName}", associationModel.FullName, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._PropertyRef.Freeze();
            }
            return result;
        }
    }
}