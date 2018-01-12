namespace OfaSchlupfer.ScriptDom {
    internal class FipsComplianceLevelHelper : OptionsHelper<FipsComplianceLevel> {
        internal static readonly FipsComplianceLevelHelper Instance = new FipsComplianceLevelHelper();

        private FipsComplianceLevelHelper() {
            base.AddOptionMapping(FipsComplianceLevel.Off, TSqlTokenType.Off);
            base.AddOptionMapping(FipsComplianceLevel.Entry, "'ENTRY'");
            base.AddOptionMapping(FipsComplianceLevel.Intermediate, "'INTERMEDIATE'");
            base.AddOptionMapping(FipsComplianceLevel.Full, "'FULL'");
        }
    }
}
