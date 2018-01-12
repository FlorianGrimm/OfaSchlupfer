using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterSecurityPolicyStatement : SecurityPolicyStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
