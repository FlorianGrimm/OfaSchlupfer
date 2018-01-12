using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UnaryExpression : ScalarExpression {
        private UnaryExpressionType _unaryExpressionType;

        private ScalarExpression _expression;

        public UnaryExpressionType UnaryExpressionType {
            get {
                return this._unaryExpressionType;
            }
            set {
                this._unaryExpressionType = value;
            }
        }

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
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
