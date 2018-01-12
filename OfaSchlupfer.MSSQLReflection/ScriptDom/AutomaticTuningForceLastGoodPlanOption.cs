using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AutomaticTuningForceLastGoodPlanOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
