using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IIfCall : PrimaryExpression {
        private BooleanExpression _predicate;

        private ScalarExpression _thenExpression;

        private ScalarExpression _elseExpression;

        public BooleanExpression Predicate {
            get {
                return this._predicate;
            }

            set {
                this.UpdateTokenInfo(value);
                this._predicate = value;
            }
        }

        public ScalarExpression ThenExpression {
            get {
                return this._thenExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._thenExpression = value;
            }
        }

        public ScalarExpression ElseExpression {
            get {
                return this._elseExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._elseExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Predicate?.Accept(visitor);
            this.ThenExpression?.Accept(visitor);
            this.ElseExpression?.Accept(visitor);
        }
    }
}
