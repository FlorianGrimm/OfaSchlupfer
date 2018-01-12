using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class RouteOptionHelper : OptionsHelper<RouteOptionKind> {
        internal static readonly RouteOptionHelper Instance = new RouteOptionHelper();

        private RouteOptionHelper() {
            base.AddOptionMapping(RouteOptionKind.Address, "ADDRESS");
            base.AddOptionMapping(RouteOptionKind.BrokerInstance, "BROKER_INSTANCE");
            base.AddOptionMapping(RouteOptionKind.Lifetime, "LIFETIME");
            base.AddOptionMapping(RouteOptionKind.MirrorAddress, "MIRROR_ADDRESS");
            base.AddOptionMapping(RouteOptionKind.ServiceName, "SERVICE_NAME");
        }
    }
}
