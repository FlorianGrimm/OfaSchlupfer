using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ContinueStatement : TSqlStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
