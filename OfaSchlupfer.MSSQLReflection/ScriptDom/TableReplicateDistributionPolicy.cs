using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableReplicateDistributionPolicy : TableDistributionPolicy {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
