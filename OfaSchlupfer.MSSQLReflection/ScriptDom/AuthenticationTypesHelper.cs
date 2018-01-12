namespace OfaSchlupfer.ScriptDom {
    internal class AuthenticationTypesHelper : OptionsHelper<AuthenticationTypes> {
        internal static readonly AuthenticationTypesHelper Instance = new AuthenticationTypesHelper();

        private AuthenticationTypesHelper() {
            base.AddOptionMapping(AuthenticationTypes.Basic, "BASIC");
            base.AddOptionMapping(AuthenticationTypes.Digest, "DIGEST");
            base.AddOptionMapping(AuthenticationTypes.Integrated, "INTEGRATED");
            base.AddOptionMapping(AuthenticationTypes.Kerberos, "KERBEROS");
            base.AddOptionMapping(AuthenticationTypes.Ntlm, "NTLM");
        }
    }
}
