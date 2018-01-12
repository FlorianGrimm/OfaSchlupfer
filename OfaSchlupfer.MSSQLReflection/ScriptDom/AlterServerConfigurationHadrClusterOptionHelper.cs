namespace OfaSchlupfer.ScriptDom {
    internal class AlterServerConfigurationHadrClusterOptionHelper : OptionsHelper<AlterServerConfigurationHadrClusterOptionKind> {
        internal static readonly AlterServerConfigurationHadrClusterOptionHelper Instance = new AlterServerConfigurationHadrClusterOptionHelper();

        private AlterServerConfigurationHadrClusterOptionHelper() {
            base.AddOptionMapping(AlterServerConfigurationHadrClusterOptionKind.Context, "CONTEXT");
        }
    }
}
