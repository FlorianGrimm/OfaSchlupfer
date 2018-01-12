using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class RetentionUnitHelper : OptionsHelper<TimeUnit> {
        internal static readonly RetentionUnitHelper Instance = new RetentionUnitHelper();

        private RetentionUnitHelper() {
            base.AddOptionMapping(TimeUnit.Days, "DAYS");
            base.AddOptionMapping(TimeUnit.Hours, "HOURS");
            base.AddOptionMapping(TimeUnit.Minutes, "MINUTES");
        }
    }
}
