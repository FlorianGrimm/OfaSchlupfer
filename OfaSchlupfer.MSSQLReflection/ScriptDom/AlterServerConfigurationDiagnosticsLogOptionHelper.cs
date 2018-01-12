namespace OfaSchlupfer.ScriptDom {
    internal class AlterServerConfigurationDiagnosticsLogOptionHelper : OptionsHelper<AlterServerConfigurationDiagnosticsLogOptionKind> {
        internal static readonly AlterServerConfigurationDiagnosticsLogOptionHelper Instance = new AlterServerConfigurationDiagnosticsLogOptionHelper();

        private AlterServerConfigurationDiagnosticsLogOptionHelper() {
            base.AddOptionMapping(AlterServerConfigurationDiagnosticsLogOptionKind.Path, "PATH");
            base.AddOptionMapping(AlterServerConfigurationDiagnosticsLogOptionKind.MaxSize, "MAX_SIZE");
            base.AddOptionMapping(AlterServerConfigurationDiagnosticsLogOptionKind.MaxFiles, "MAX_FILES");
        }
    }
}
