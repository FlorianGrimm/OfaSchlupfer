using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class AutomaticTuningForceLastGoodPlanOptionHelper : OptionsHelper<AutomaticTuningOptionState> {
        internal static readonly AutomaticTuningForceLastGoodPlanOptionHelper Instance = new AutomaticTuningForceLastGoodPlanOptionHelper();

        private AutomaticTuningForceLastGoodPlanOptionHelper() {
            base.AddOptionMapping(AutomaticTuningOptionState.Off, "OFF");
            base.AddOptionMapping(AutomaticTuningOptionState.On, "ON");
            base.AddOptionMapping(AutomaticTuningOptionState.Default, "DEFAULT");
        }
    }
}
