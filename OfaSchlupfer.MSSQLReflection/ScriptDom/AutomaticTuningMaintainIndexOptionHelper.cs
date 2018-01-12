using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class AutomaticTuningMaintainIndexOptionHelper : OptionsHelper<AutomaticTuningOptionState> {
        internal static readonly AutomaticTuningMaintainIndexOptionHelper Instance = new AutomaticTuningMaintainIndexOptionHelper();

        private AutomaticTuningMaintainIndexOptionHelper() {
            base.AddOptionMapping(AutomaticTuningOptionState.Off, "OFF");
            base.AddOptionMapping(AutomaticTuningOptionState.On, "ON");
            base.AddOptionMapping(AutomaticTuningOptionState.Default, "DEFAULT");
        }
    }
}
