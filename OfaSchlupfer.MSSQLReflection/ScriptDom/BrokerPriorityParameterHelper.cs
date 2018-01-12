using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class BrokerPriorityParameterHelper : OptionsHelper<BrokerPriorityParameterType> {
        internal static readonly BrokerPriorityParameterHelper Instance = new BrokerPriorityParameterHelper();

        private BrokerPriorityParameterHelper() {
            base.AddOptionMapping(BrokerPriorityParameterType.ContractName, "CONTRACT_NAME");
            base.AddOptionMapping(BrokerPriorityParameterType.LocalServiceName, "LOCAL_SERVICE_NAME");
            base.AddOptionMapping(BrokerPriorityParameterType.PriorityLevel, "PRIORITY_LEVEL");
            base.AddOptionMapping(BrokerPriorityParameterType.RemoteServiceName, "REMOTE_SERVICE_NAME");
        }
    }
}
