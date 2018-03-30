namespace OfaSchlupfer.ModelOData.Edm {
    using System.Collections.Generic;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlEntityContainerModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;

        public CsdlEntityContainerModel() {
            this.EntitySet = new CsdlCollection<CsdlEntitySetModel>((item) => { item.OwnerEntityContainerModel = this; });
            this.AssociationSet = new CsdlCollection<CsdlAssociationSetModel>((item) => { item.OwnerEntityContainerModel = this; });
        }
        public string Name;
        public bool IsDefaultEntityContainer;
        public readonly CsdlCollection<CsdlEntitySetModel> EntitySet;
        public readonly CsdlCollection<CsdlAssociationSetModel> AssociationSet;


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                if ((object)value != null) {
                    this.EntitySet.Broadcast();
                    this.AssociationSet.Broadcast();
                }
            }
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schema, CsdlErrors errors) {
            foreach (var entitySet in this.EntitySet) {
                entitySet.ResolveNames(edmxModel, schema, this, errors);
            }
            foreach (var associationSet in this.AssociationSet) {
                associationSet.ResolveNames(edmxModel, schema, this, errors);
            }
        }
    }
}