using System;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlReferentialConstraintPartnerV3Model : CsdlAnnotationalModel {
        public readonly CsdlCollection<CsdlPropertyRefModel> PropertyRef;
        private CsdlSchemaModel _SchemaModel;
        private CsdlReferentialConstraintV3Model _OwnerReferentialConstraintModel;
        private string _RoleName;
        private CsdlAssociationEndModel _RoleEnd;

        public CsdlReferentialConstraintPartnerV3Model() {
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

        public CsdlReferentialConstraintV3Model OwnerReferentialConstraintModel {
            get {
                return this._OwnerReferentialConstraintModel;
            }
            set {
                if (ReferenceEquals(this._OwnerReferentialConstraintModel, value)) { return; }
                this._OwnerReferentialConstraintModel = value;
                this.SchemaModel = value?.SchemaModel;
            }
        }

        public string RoleName {
            get {
                return this._RoleName;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._RoleName, value, StringComparison.Ordinal)) { return; }
                this._RoleName = value;
                this._RoleEnd = null;
            }
        }

        public CsdlAssociationEndModel RoleEnd {
            get {
                if (this._RoleEnd == null) {
                    this.ResolveNames(CsdlErrors.GetIgnorance());
                }
                return this._RoleEnd;
            }
            set {
                this._RoleEnd = value;
                this._RoleName = null;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            this.ResolveNameRoleEnd(errors);
            foreach (var propertyRef in this.PropertyRef) {
                propertyRef.ResolveNames(errors);
            }
        }

        public void ResolveNameRoleEnd(CsdlErrors errors) {
            if (this._RoleEnd == null && this._RoleName != null) {
                var referentialConstraintModel = this.OwnerReferentialConstraintModel;
                var associationModel = referentialConstraintModel.OwnerAssociationModel;
                if (associationModel != null) {
                    var end = associationModel.FindAssociationEnd(this._RoleName);
                    if (end != null) {
                        this.RoleEnd = end;
                    } else {
                        errors.AddError($"Role {this._RoleName} not found in {associationModel.FullName}.");
                    }
                }
            }
        }
    }
}