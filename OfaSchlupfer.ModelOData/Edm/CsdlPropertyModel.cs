using System;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPropertyModel : CsdlAnnotationalModel {
        public string Name;
        // Collection(Edm.DateTime)
        public string TypeName;
        public bool Nullable;
        public int MaxLength;
        public bool FixedLength;
        public int Precision;
        public int Scale;
        public bool Unicode;
        public string Collation;
        public string SRID;
        public string DefaultValue;
        public string ConcurrencyMode;

        public CsdlPropertyModel() {
            this.Nullable = true;
            this.Unicode = true;
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel { get; internal set; }


        public void BuildNameResolver(CsdlEntityTypeModel entityType, CsdlNameResolver nameResolver) {
            nameResolver.AddProperty(this.SchemaModel.Namespace, entityType.Name, this.Name, this);
        }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            // TODO: resolve this.TypeName
        }

    }
}