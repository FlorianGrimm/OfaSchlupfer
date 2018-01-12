using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GrandTotalGroupingSpecification : GroupingSpecification {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
