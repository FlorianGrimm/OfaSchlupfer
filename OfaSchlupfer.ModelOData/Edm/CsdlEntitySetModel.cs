namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlEntitySetModel : CsdlAnnotationalModel {
        public string Name;
        public string EntityTypeName;
        public CsdlEntityTypeModel EntityTypeModelObject;
        public CsdlEntityContainerModel EntityContainer;
        public CsdlEntitySetModel() {
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel { get; internal set; }

        public void BuildNameResolver(CsdlEntityContainerModel entityContainer, CsdlNameResolver nameResolver) {
            this.EntityContainer = entityContainer;
            nameResolver.AddEntitySet(this.SchemaModel.Namespace, entityContainer.Name, this.Name, this);
        }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            // var name = CsdlNameResolver.ConcatDot(this.EntityContainer.Name, this.EntityTypeName);
            var found = nameResolver.FindNSName(this.EntityTypeName);
            if (found.Count == 1) {
                var entityType = found[0].EntityType;
                if (entityType != null) {
                    EntityTypeModelObject = entityType;
                    return;
                }
            }
            {
                EntityTypeModelObject = null;
            }
        }
    }
}