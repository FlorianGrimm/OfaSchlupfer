using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IndexExpressionOption : IndexOption {
        private ScalarExpression _expression;

        public ScalarExpression Expression {
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
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
        }
    }
}
