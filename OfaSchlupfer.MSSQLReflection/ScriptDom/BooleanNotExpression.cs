using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BooleanNotExpression : BooleanExpression {
        private BooleanExpression _expression;

        public BooleanExpression Expression {
            get {
                return this._expression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
