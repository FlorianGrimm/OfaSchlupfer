using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TSEqualCall : BooleanExpression {
        private ScalarExpression _firstExpression;

        private ScalarExpression _secondExpression;

        public ScalarExpression FirstExpression {
            get {
                return this._firstExpression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._firstExpression = value;
            }
        }

        public ScalarExpression SecondExpression {
            get {
                return this._secondExpression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._secondExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
