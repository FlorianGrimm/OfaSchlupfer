namespace OfaSchlupfer.ScriptDom {
    internal class EndpointTypesHelper : OptionsHelper<EndpointType> {
        internal static readonly EndpointTypesHelper Instance = new EndpointTypesHelper();

        private EndpointTypesHelper() {
            base.AddOptionMapping(EndpointType.DatabaseMirroring, "DATABASE_MIRRORING");
            base.AddOptionMapping(EndpointType.Soap, "SOAP");
            base.AddOptionMapping(EndpointType.ServiceBroker, "SERVICE_BROKER");
            base.AddOptionMapping(EndpointType.TSql, "TSQL");
        }
    }
}
