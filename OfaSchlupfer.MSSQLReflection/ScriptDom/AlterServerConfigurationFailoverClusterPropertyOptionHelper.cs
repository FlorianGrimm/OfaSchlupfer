namespace OfaSchlupfer.ScriptDom {
    internal class AlterServerConfigurationFailoverClusterPropertyOptionHelper : OptionsHelper<AlterServerConfigurationFailoverClusterPropertyOptionKind> {
        internal static readonly AlterServerConfigurationFailoverClusterPropertyOptionHelper Instance = new AlterServerConfigurationFailoverClusterPropertyOptionHelper();

        private AlterServerConfigurationFailoverClusterPropertyOptionHelper() {
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.VerboseLogging, "VerboseLogging");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.SqlDumperDumpFlags, "SqlDumperDumpFlags");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.SqlDumperDumpPath, "SqlDumperDumpPath");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.SqlDumperDumpTimeout, "SqlDumperDumpTimeout");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.FailureConditionLevel, "FailureConditionLevel");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.HealthCheckTimeout, "HealthCheckTimeout");
        }
    }
}
