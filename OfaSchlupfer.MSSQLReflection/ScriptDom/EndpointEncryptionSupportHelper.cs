namespace OfaSchlupfer.ScriptDom {
    internal class EndpointEncryptionSupportHelper : OptionsHelper<EndpointEncryptionSupport> {
        internal static readonly EndpointEncryptionSupportHelper Instance = new EndpointEncryptionSupportHelper();

        private EndpointEncryptionSupportHelper() {
            base.AddOptionMapping(EndpointEncryptionSupport.Disabled, "DISABLED");
            base.AddOptionMapping(EndpointEncryptionSupport.Required, "REQUIRED");
            base.AddOptionMapping(EndpointEncryptionSupport.Supported, "SUPPORTED");
        }
    }
}
