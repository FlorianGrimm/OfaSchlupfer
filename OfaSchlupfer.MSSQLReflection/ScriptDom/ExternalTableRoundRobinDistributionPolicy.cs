using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExternalTableRoundRobinDistributionPolicy : ExternalTableDistributionPolicy {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
