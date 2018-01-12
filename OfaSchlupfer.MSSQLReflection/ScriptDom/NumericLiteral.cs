using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class NumericLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Numeric;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
