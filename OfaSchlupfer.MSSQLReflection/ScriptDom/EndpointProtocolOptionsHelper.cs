namespace OfaSchlupfer.ScriptDom {
    internal class EndpointProtocolOptionsHelper : OptionsHelper<EndpointProtocolOptions> {
        internal static readonly EndpointProtocolOptionsHelper Instance = new EndpointProtocolOptionsHelper();

        private EndpointProtocolOptionsHelper() {
            base.AddOptionMapping(EndpointProtocolOptions.HttpAuthenticationRealm, "AUTH_REALM");
            base.AddOptionMapping(EndpointProtocolOptions.HttpAuthentication, "AUTHENTICATION");
            base.AddOptionMapping(EndpointProtocolOptions.HttpClearPort, "CLEAR_PORT");
            base.AddOptionMapping(EndpointProtocolOptions.HttpCompression, "COMPRESSION");
            base.AddOptionMapping(EndpointProtocolOptions.HttpDefaultLogonDomain, "DEFAULT_LOGON_DOMAIN");
            base.AddOptionMapping(EndpointProtocolOptions.HttpPath, "PATH");
            base.AddOptionMapping(EndpointProtocolOptions.HttpPorts, "PORTS");
            base.AddOptionMapping(EndpointProtocolOptions.HttpSite, "SITE");
            base.AddOptionMapping(EndpointProtocolOptions.HttpSslPort, "SSL_PORT");
            base.AddOptionMapping(EndpointProtocolOptions.TcpListenerIP, "LISTENER_IP");
            base.AddOptionMapping(EndpointProtocolOptions.TcpListenerPort, "LISTENER_PORT");
        }
    }
}
