namespace OfaSchlupfer.ScriptDom {
    internal class ApplicationRoleOptionHelper : OptionsHelper<ApplicationRoleOptionKind> {
        internal static readonly ApplicationRoleOptionHelper Instance = new ApplicationRoleOptionHelper();

        private ApplicationRoleOptionHelper() {
            base.AddOptionMapping(ApplicationRoleOptionKind.DefaultSchema, "DEFAULT_SCHEMA");
            base.AddOptionMapping(ApplicationRoleOptionKind.Password, "PASSWORD");
            base.AddOptionMapping(ApplicationRoleOptionKind.Name, "NAME");
            base.AddOptionMapping(ApplicationRoleOptionKind.Login, "LOGIN");
        }
    }
}
