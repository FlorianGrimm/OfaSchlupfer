namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPropertyRefModel : CsdlAnnotationalModel {
        public CsdlPropertyRefModel() {
        }

        public string Name;

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel { get; internal set; }


        public void ResolveNames(CsdlNameResolver nameResolver) {
            // TODO: resolve this.Name
        }
    }
}