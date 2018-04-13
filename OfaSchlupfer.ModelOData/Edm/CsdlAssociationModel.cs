namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlAssociationModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;

        public CsdlAssociationModel() {
            this.AssociationEnd = new CsdlCollection<CsdlAssociationEndModel>((item) => { item.Owner = this; });
            this.ReferentialConstraint = new CsdlCollection<CsdlReferentialConstraintV3Model>((item) => { item.OwnerAssociationModel = this; });
        }
        public string Name;
        public readonly CsdlCollection<CsdlAssociationEndModel> AssociationEnd;
        public readonly CsdlCollection<CsdlReferentialConstraintV3Model> ReferentialConstraint;

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

        public void ResolveNames(ModelErrors errors) {
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