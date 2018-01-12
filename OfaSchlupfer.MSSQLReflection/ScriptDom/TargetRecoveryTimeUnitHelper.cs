using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class TargetRecoveryTimeUnitHelper : OptionsHelper<TimeUnit> {
        internal static readonly TargetRecoveryTimeUnitHelper Instance = new TargetRecoveryTimeUnitHelper();

        private TargetRecoveryTimeUnitHelper() {
            base.AddOptionMapping(TimeUnit.Minutes, "MINUTES");
            base.AddOptionMapping(TimeUnit.Seconds, "SECONDS");
        }
    }
}
