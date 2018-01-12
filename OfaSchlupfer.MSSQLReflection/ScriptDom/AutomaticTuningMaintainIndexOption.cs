using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AutomaticTuningMaintainIndexOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
