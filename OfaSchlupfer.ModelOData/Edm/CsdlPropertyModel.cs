namespace OfaSchlupfer.ModelOData.Edm {
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

    }
}