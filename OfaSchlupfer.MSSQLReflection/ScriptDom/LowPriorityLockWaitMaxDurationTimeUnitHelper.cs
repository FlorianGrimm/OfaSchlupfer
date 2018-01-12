using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class LowPriorityLockWaitMaxDurationTimeUnitHelper : OptionsHelper<TimeUnit> {
        internal static readonly LowPriorityLockWaitMaxDurationTimeUnitHelper Instance = new LowPriorityLockWaitMaxDurationTimeUnitHelper();

        private LowPriorityLockWaitMaxDurationTimeUnitHelper() {
            base.AddOptionMapping(TimeUnit.Minutes, "MINUTES");
        }
    }
}
