using System;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlReferentialConstraintPartnerModel : CsdlAnnotationalModel {
        public readonly CsdlCollection<CsdlPropertyRefModel> PropertyRef;
        private CsdlSchemaModel _SchemaModel;
        private CsdlReferentialConstraintModel _OwnerReferentialConstraintModel;
        private string _RoleName;
        private CsdlAssociationEndModel _RoleEnd;

        public CsdlReferentialConstraintPartnerModel() {
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

        public CsdlReferentialConstraintModel OwnerReferentialConstraintModel {
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
                //this.OwnerReferentialConstraintModel.f
            }
        }
    }
}