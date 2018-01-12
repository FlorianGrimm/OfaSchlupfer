using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class AutomaticTuningDropIndexOptionHelper : OptionsHelper<AutomaticTuningOptionState> {
        internal static readonly AutomaticTuningDropIndexOptionHelper Instance = new AutomaticTuningDropIndexOptionHelper();

        private AutomaticTuningDropIndexOptionHelper() {
            base.AddOptionMapping(AutomaticTuningOptionState.Off, "OFF");
            base.AddOptionMapping(AutomaticTuningOptionState.On, "ON");
            base.AddOptionMapping(AutomaticTuningOptionState.Default, "DEFAULT");
        }
    }
}
