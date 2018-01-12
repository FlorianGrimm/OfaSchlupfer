namespace OfaSchlupfer.ScriptDom {
    internal class AvailabilityReplicaOptionsHelper : OptionsHelper<AvailabilityReplicaOptionKind> {
        public static readonly AvailabilityReplicaOptionsHelper Instance = new AvailabilityReplicaOptionsHelper();

        private AvailabilityReplicaOptionsHelper() {
            base.AddOptionMapping(AvailabilityReplicaOptionKind.ApplyDelay, "APPLY_DELAY");
            base.AddOptionMapping(AvailabilityReplicaOptionKind.AvailabilityMode, "AVAILABILITY_MODE");
            base.AddOptionMapping(AvailabilityReplicaOptionKind.EndpointUrl, "ENDPOINT_URL");
            base.AddOptionMapping(AvailabilityReplicaOptionKind.SecondaryRole, "SECONDARY_ROLE");
            base.AddOptionMapping(AvailabilityReplicaOptionKind.SessionTimeout, "SESSION_TIMEOUT");
        }
    }
}
