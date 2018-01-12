using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RaiseErrorLegacyStatement : TSqlStatement {
        private ScalarExpression _firstParameter;

        private ValueExpression _secondParameter;

        public ScalarExpression FirstParameter {
            get {
                return this._firstParameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._firstParameter = value;
            }
        }

        public ValueExpression SecondParameter {
            get {
                return this._secondParameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._secondParameter = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FirstParameter?.Accept(visitor);
            this.SecondParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
