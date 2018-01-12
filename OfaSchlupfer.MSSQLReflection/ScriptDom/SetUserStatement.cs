using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetUserStatement : TSqlStatement {
        private ValueExpression _userName;

        private bool _withNoReset;

        public ValueExpression UserName {
            get {
                return this._userName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._userName = value;
            }
        }

        public bool WithNoReset {
            get {
                return this._withNoReset;
            }
            set {
                this._withNoReset = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.UserName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
