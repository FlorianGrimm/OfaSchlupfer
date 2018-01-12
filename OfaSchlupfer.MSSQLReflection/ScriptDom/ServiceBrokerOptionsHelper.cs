namespace OfaSchlupfer.ScriptDom {
    internal class ServiceBrokerOptionsHelper : OptionsHelper<ServiceBrokerOption> {
        internal static readonly ServiceBrokerOptionsHelper Instance = new ServiceBrokerOptionsHelper();

        private ServiceBrokerOptionsHelper() {
            base.AddOptionMapping(ServiceBrokerOption.NewBroker, "NEW_BROKER");
            base.AddOptionMapping(ServiceBrokerOption.EnableBroker, "ENABLE_BROKER");
            base.AddOptionMapping(ServiceBrokerOption.ErrorBrokerConversations, "ERROR_BROKER_CONVERSATIONS");
        }
    }
}
