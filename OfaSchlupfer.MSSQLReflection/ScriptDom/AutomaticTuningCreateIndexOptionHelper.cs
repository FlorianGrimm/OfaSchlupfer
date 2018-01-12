using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class AutomaticTuningCreateIndexOptionHelper : OptionsHelper<AutomaticTuningOptionState> {
        internal static readonly AutomaticTuningCreateIndexOptionHelper Instance = new AutomaticTuningCreateIndexOptionHelper();

        private AutomaticTuningCreateIndexOptionHelper() {
            base.AddOptionMapping(AutomaticTuningOptionState.Off, "OFF");
            base.AddOptionMapping(AutomaticTuningOptionState.On, "ON");
            base.AddOptionMapping(AutomaticTuningOptionState.Default, "DEFAULT");
        }
    }
}
