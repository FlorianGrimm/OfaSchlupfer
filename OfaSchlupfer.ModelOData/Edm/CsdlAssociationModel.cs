namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlAssociationModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;

        public CsdlAssociationModel() {
            this.AssociationEnd = new CsdlCollection<CsdlAssociationEndModel>((item) => { item.OwnerAssociationModel = this; });
            this.ReferentialConstraint = new CsdlCollection<CsdlReferentialConstraintModel>((item) => { item.OwnerAssociationModel = this; });
        }
        public string Name;
        public readonly CsdlCollection<CsdlAssociationEndModel> AssociationEnd;
        public readonly CsdlCollection<CsdlReferentialConstraintModel> ReferentialConstraint;

        public string FullName => (this.SchemaModel?.Namespace ?? string.Empty) + "." + this.Name;


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                this.AssociationEnd.Broadcast();
                this.ReferentialConstraint.Broadcast();
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            foreach (var associationEnd in this.AssociationEnd) {
                associationEnd.ResolveNames(errors);
            }
            foreach (var referentialConstraint in this.ReferentialConstraint) {
                referentialConstraint.ResolveNames(errors);
            }
        }

        public CsdlAssociationEndModel FindAssociationEnd(string roleName) {
            foreach (var associationEnd in this.AssociationEnd) {
                if (string.Equals(associationEnd.RoleName, roleName, StringComparison.OrdinalIgnoreCase)) {
                    return associationEnd;
                }
            }
            return null;
        }
    }
}