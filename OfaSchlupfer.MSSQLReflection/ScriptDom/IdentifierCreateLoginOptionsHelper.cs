namespace OfaSchlupfer.ScriptDom {
    internal class IdentifierCreateLoginOptionsHelper : OptionsHelper<PrincipalOptionKind> {
        internal static readonly IdentifierCreateLoginOptionsHelper Instance = new IdentifierCreateLoginOptionsHelper();

        private IdentifierCreateLoginOptionsHelper() {
            base.AddOptionMapping(PrincipalOptionKind.DefaultDatabase, "DEFAULT_DATABASE");
            base.AddOptionMapping(PrincipalOptionKind.DefaultLanguage, "DEFAULT_LANGUAGE");
            base.AddOptionMapping(PrincipalOptionKind.Credential, "CREDENTIAL");
        }
    }
}
