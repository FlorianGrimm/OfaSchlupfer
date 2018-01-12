using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AutomaticTuningCreateIndexOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
