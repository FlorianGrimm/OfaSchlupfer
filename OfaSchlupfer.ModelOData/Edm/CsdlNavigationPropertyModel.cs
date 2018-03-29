namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlNavigationPropertyModel {
        public string Name;
        // V3
        public string Relationship;
        public string FromRole;
        public string ToRole;
        public bool ContainsTarget;

        // V4
        public string TypeName;
        public string Partner;
        public bool Nullable;

        public CsdlNavigationPropertyModel() {
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel { get; internal set; }


        public void BuildNameResolver(CsdlEntityTypeModel entityType, CsdlNameResolver nameResolver) {
            nameResolver.AddNavigationProperty(this.SchemaModel.Namespace, entityType.Name, this.Name, this);
        }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            // TODO: resolve
        }
    }
}