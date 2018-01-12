namespace OfaSchlupfer.ScriptDom {
    internal class EndpointStateHelper : OptionsHelper<EndpointState> {
        internal static readonly EndpointStateHelper Instance = new EndpointStateHelper();

        private EndpointStateHelper() {
            base.AddOptionMapping(EndpointState.Disabled, "DISABLED");
            base.AddOptionMapping(EndpointState.Started, "STARTED");
            base.AddOptionMapping(EndpointState.Stopped, "STOPPED");
        }
    }
}
