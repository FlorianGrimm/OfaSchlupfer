using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MaxLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Max;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
