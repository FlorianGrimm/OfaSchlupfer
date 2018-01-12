using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class AutomaticTuningOptionsHelper : OptionsHelper<AutomaticTuningOptionKind> {
        internal static readonly AutomaticTuningOptionsHelper Instance = new AutomaticTuningOptionsHelper();

        private AutomaticTuningOptionsHelper() {
            base.AddOptionMapping(AutomaticTuningOptionKind.Force_Last_Good_Plan, "FORCE_LAST_GOOD_PLAN");
            base.AddOptionMapping(AutomaticTuningOptionKind.Create_Index, "CREATE_INDEX");
            base.AddOptionMapping(AutomaticTuningOptionKind.Drop_Index, "DROP_INDEX");
            base.AddOptionMapping(AutomaticTuningOptionKind.Maintain_Index, "MAINTAIN_INDEX");
        }
    }
}
