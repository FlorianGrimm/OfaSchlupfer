namespace OfaSchlupfer.ScriptDom {
    internal class CertificateOptionKindsHelper : OptionsHelper<CertificateOptionKinds> {
        internal static readonly CertificateOptionKindsHelper Instance = new CertificateOptionKindsHelper();

        private CertificateOptionKindsHelper() {
            base.AddOptionMapping(CertificateOptionKinds.Subject, "SUBJECT");
            base.AddOptionMapping(CertificateOptionKinds.StartDate, "START_DATE");
            base.AddOptionMapping(CertificateOptionKinds.ExpiryDate, "EXPIRY_DATE");
        }
    }
}
