namespace OfaSchlupfer.ScriptDom {
    internal class AlterAvailabilityGroupActionTypeHelper : OptionsHelper<AlterAvailabilityGroupActionType> {
        public static readonly AlterAvailabilityGroupActionTypeHelper Instance = new AlterAvailabilityGroupActionTypeHelper();

        private AlterAvailabilityGroupActionTypeHelper() {
            base.AddOptionMapping(AlterAvailabilityGroupActionType.Failover, "FAILOVER");
            base.AddOptionMapping(AlterAvailabilityGroupActionType.ForceFailoverAllowDataLoss, "FORCE_FAILOVER_ALLOW_DATA_LOSS");
            base.AddOptionMapping(AlterAvailabilityGroupActionType.Join, TSqlTokenType.Join);
            base.AddOptionMapping(AlterAvailabilityGroupActionType.Offline, "OFFLINE");
            base.AddOptionMapping(AlterAvailabilityGroupActionType.Online, "ONLINE");
        }
    }
}
