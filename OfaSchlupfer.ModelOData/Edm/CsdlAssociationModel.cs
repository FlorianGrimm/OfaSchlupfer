namespace OfaSchlupfer.ModelOData.Edm {
    using System.Collections.Generic;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlAssociationModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;

        public CsdlAssociationModel() {
            this.AssociationEnd = new CsdlCollection<CsdlAssociationEndModel>((item) => { item.SchemaModel = this.SchemaModel; });
            this.ReferentialConstraint = new CsdlCollection<CsdlReferentialConstraintModel>((item) => { item.SchemaModel = this.SchemaModel; });
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
            internal set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                if ((object)value != null) {
                    this.AssociationEnd.Broadcast();
                    this.ReferentialConstraint.Broadcast();
                }
            }
        }

        public void BuildNameResolver(CsdlNameResolver nameResolver) {
            nameResolver.AddAssociation(this.SchemaModel.Namespace, this.Name, this);
        }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            foreach (var associationEnd in this.AssociationEnd) {
                associationEnd.ResolveNames(nameResolver);
            }
            foreach (var referentialConstraint in this.ReferentialConstraint) {
                referentialConstraint.ResolveNames(nameResolver);
            }
        }
    }
}