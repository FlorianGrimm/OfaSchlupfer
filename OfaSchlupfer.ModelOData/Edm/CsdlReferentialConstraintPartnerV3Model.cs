using System;
using OfaSchlupfer.Model;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlReferentialConstraintPartnerV3Model : CsdlAnnotationalModel {
        public readonly CsdlCollection<CsdlPropertyRefModel> PropertyRef;
        private CsdlReferentialConstraintV3Model _OwnerReferentialConstraintModel;
        private string _RoleName;
        private CsdlAssociationEndModel _RoleEnd;

        public CsdlReferentialConstraintPartnerV3Model() {
            this.PropertyRef = new CsdlCollection<CsdlPropertyRefModel>((item) => { item.OwnerReferentialConstraintPartnerModel = this; });
        }

        public CsdlReferentialConstraintV3Model OwnerReferentialConstraintModel {
            get {
                return this._OwnerReferentialConstraintModel;
            }
            set {
                if (ReferenceEquals(this._OwnerReferentialConstraintModel, value)) { return; }
                this._OwnerReferentialConstraintModel = value;
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
                    this.ResolveNames(ModelErrors.GetIgnorance());
                }
                return this._RoleEnd;
            }
            set {
                this._RoleEnd = value;
                this._RoleName = null;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNameRoleEnd(errors);
            foreach (var propertyRef in this.PropertyRef) {
                propertyRef.ResolveNames(errors);
            }
        }

        public void ResolveNameRoleEnd(ModelErrors errors) {
            if (this._RoleEnd == null && this._RoleName != null) {
                var referentialConstraintModel = this.OwnerReferentialConstraintModel;
                var associationModel = referentialConstraintModel.OwnerAssociationModel;
                if (associationModel != null) {
                    var end = associationModel.FindAssociationEnd(this._RoleName);
                    if (end != null) {
                        this.RoleEnd = end;
                    } else {
                        errors.AddErrorXmlParsing($"Role {this._RoleName} not found in {associationModel.FullName}.");
                    }
                }
            }
        }
    }
}