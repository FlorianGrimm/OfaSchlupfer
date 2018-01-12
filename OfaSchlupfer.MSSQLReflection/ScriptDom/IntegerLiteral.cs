using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IntegerLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Integer;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
