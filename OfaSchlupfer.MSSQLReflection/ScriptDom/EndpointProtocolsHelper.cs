namespace OfaSchlupfer.ScriptDom {
    internal class EndpointProtocolsHelper : OptionsHelper<EndpointProtocol> {
        internal static readonly EndpointProtocolsHelper Instance = new EndpointProtocolsHelper();

        private EndpointProtocolsHelper() {
            base.AddOptionMapping(EndpointProtocol.Tcp, "TCP");
            base.AddOptionMapping(EndpointProtocol.Http, "HTTP");
        }
    }
}
