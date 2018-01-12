using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BooleanIsNullExpression : BooleanExpression {
        private bool _isNot;

        private ScalarExpression _expression;

        public bool IsNot {
            get {
                return this._isNot;
            }
            set {
                this._isNot = value;
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
