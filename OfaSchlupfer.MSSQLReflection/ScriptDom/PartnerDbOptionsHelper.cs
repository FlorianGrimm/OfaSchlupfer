namespace OfaSchlupfer.ScriptDom {
    internal class PartnerDbOptionsHelper : OptionsHelper<PartnerDatabaseOptionKind> {
        public static readonly PartnerDbOptionsHelper Instance = new PartnerDbOptionsHelper();

        private PartnerDbOptionsHelper() {
            base.AddOptionMapping(PartnerDatabaseOptionKind.Failover, "FAILOVER");
            base.AddOptionMapping(PartnerDatabaseOptionKind.ForceServiceAllowDataLoss, "FORCE_SERVICE_ALLOW_DATA_LOSS");
            base.AddOptionMapping(PartnerDatabaseOptionKind.Off, TSqlTokenType.Off);
            base.AddOptionMapping(PartnerDatabaseOptionKind.Resume, "RESUME");
            base.AddOptionMapping(PartnerDatabaseOptionKind.Suspend, "SUSPEND");
            base.AddOptionMapping(PartnerDatabaseOptionKind.Timeout, "TIMEOUT");
        }
    }
}
