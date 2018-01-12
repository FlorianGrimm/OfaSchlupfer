using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ThrowStatement : TSqlStatement {
        private ValueExpression _errorNumber;

        private ValueExpression _message;

        private ValueExpression _state;

        public ValueExpression ErrorNumber {
            get {
                return this._errorNumber;
            }
            set {
                base.UpdateTokenInfo(value);
                this._errorNumber = value;
            }
        }

        public ValueExpression Message {
            get {
                return this._message;
            }
            set {
                base.UpdateTokenInfo(value);
                this._message = value;
            }
        }

        public ValueExpression State {
            get {
                return this._state;
            }
            set {
                base.UpdateTokenInfo(value);
                this._state = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ErrorNumber?.Accept(visitor);
            this.Message?.Accept(visitor);
            this.State?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
