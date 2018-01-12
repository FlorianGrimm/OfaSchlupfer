namespace OfaSchlupfer.ScriptDom {
    internal class SecurityLoginOptionsHelper : OptionsHelper<PrincipalOptionKind> {
        internal static readonly SecurityLoginOptionsHelper Instance = new SecurityLoginOptionsHelper();

        private SecurityLoginOptionsHelper() {
            base.AddOptionMapping(PrincipalOptionKind.CheckExpiration, "CHECK_EXPIRATION");
            base.AddOptionMapping(PrincipalOptionKind.CheckPolicy, "CHECK_POLICY");
        }
    }
}
