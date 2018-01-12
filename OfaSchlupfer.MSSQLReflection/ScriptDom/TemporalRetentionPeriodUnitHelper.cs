namespace OfaSchlupfer.ScriptDom {
    internal class TemporalRetentionPeriodUnitHelper : OptionsHelper<TemporalRetentionPeriodUnit> {
        internal static readonly TemporalRetentionPeriodUnitHelper Instance = new TemporalRetentionPeriodUnitHelper();

        private TemporalRetentionPeriodUnitHelper() {
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Day, "DAY");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Days, "DAYS");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Week, "WEEK");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Weeks, "WEEKS");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Month, "MONTH");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Months, "MONTHS");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Year, "YEAR");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Years, "YEARS");
        }
    }
}
