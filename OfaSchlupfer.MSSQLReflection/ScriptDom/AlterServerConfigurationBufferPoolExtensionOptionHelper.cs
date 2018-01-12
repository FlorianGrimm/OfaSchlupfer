namespace OfaSchlupfer.ScriptDom {
    internal class AlterServerConfigurationBufferPoolExtensionOptionHelper : OptionsHelper<AlterServerConfigurationBufferPoolExtensionOptionKind> {
        internal static readonly AlterServerConfigurationBufferPoolExtensionOptionHelper Instance = new AlterServerConfigurationBufferPoolExtensionOptionHelper();

        private AlterServerConfigurationBufferPoolExtensionOptionHelper() {
            base.AddOptionMapping(AlterServerConfigurationBufferPoolExtensionOptionKind.FileName, "FILENAME");
            base.AddOptionMapping(AlterServerConfigurationBufferPoolExtensionOptionKind.Size, "SIZE");
        }
    }
}
