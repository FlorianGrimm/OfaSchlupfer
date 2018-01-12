namespace OfaSchlupfer.ScriptDom {
    internal class MigrationStateHelper : OptionsHelper<MigrationState> {
        public static MigrationStateHelper Instance = new MigrationStateHelper();

        private MigrationStateHelper() {
            base.AddOptionMapping(MigrationState.Paused, "PAUSED");
            base.AddOptionMapping(MigrationState.Outbound, "OUTBOUND");
            base.AddOptionMapping(MigrationState.Inbound, "INBOUND");
        }
    }
}
