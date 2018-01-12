namespace OfaSchlupfer.ScriptDom {
    internal class RdaTableOptionHelper : OptionsHelper<RdaTableOption> {
        public static RdaTableOptionHelper Instance = new RdaTableOptionHelper();

        private RdaTableOptionHelper() {
            base.AddOptionMapping(RdaTableOption.Enable, "ON");
            base.AddOptionMapping(RdaTableOption.Disable, "OFF");
            base.AddOptionMapping(RdaTableOption.OffWithoutDataRecovery, "OFF_WITHOUT_DATA_RECOVERY");
        }
    }
}
