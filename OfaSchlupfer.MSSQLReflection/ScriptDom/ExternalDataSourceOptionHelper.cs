namespace OfaSchlupfer.ScriptDom {
    internal class ExternalDataSourceOptionHelper : OptionsHelper<ExternalDataSourceOptionKind> {
        internal static readonly ExternalDataSourceOptionHelper Instance = new ExternalDataSourceOptionHelper();

        private ExternalDataSourceOptionHelper() {
            base.AddOptionMapping(ExternalDataSourceOptionKind.ResourceManagerLocation, "RESOURCE_MANAGER_LOCATION");
            base.AddOptionMapping(ExternalDataSourceOptionKind.Credential, "CREDENTIAL");
            base.AddOptionMapping(ExternalDataSourceOptionKind.DatabaseName, "DATABASE_NAME");
            base.AddOptionMapping(ExternalDataSourceOptionKind.ShardMapName, "SHARD_MAP_NAME");
        }
    }
}
