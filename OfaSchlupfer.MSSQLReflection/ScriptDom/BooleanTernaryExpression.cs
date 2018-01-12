using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BooleanTernaryExpression : BooleanExpression {
        private BooleanTernaryExpressionType _ternaryExpressionType;

        private ScalarExpression _firstExpression;

        private ScalarExpression _secondExpression;

        private ScalarExpression _thirdExpression;

        public BooleanTernaryExpressionType TernaryExpressionType {
            get {
                return this._ternaryExpressionType;
            }
            set {
                this._ternaryExpressionType = value;
            }
        }

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

        public ScalarExpression ThirdExpression {
            get {
                return this._thirdExpression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._thirdExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            this.ThirdExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
