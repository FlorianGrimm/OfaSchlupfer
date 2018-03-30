namespace OfaSchlupfer.ModelOData.Edm {
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

        public void BuildNameResolver(CsdlNameResolver nameResolver) {
            nameResolver.AddAssociation(this.SchemaModel.Namespace, this.Name, this);
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel csdlSchemaModel, CsdlErrors errors) {
            foreach (var associationEnd in this.AssociationEnd) {
                associationEnd.ResolveNames(edmxModel, csdlSchemaModel, this, errors);
            }
            foreach (var referentialConstraint in this.ReferentialConstraint) {
                referentialConstraint.ResolveNames(edmxModel, csdlSchemaModel, this, errors);
            }
        }
    }
}