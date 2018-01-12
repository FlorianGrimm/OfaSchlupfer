using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SqlCommandIdentifier : Identifier {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
