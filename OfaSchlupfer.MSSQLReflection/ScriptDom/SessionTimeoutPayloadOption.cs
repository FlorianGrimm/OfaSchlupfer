using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SessionTimeoutPayloadOption : PayloadOption {
        private bool _isNever;

        private Literal _timeout;

        public bool IsNever {
            get {
                return this._isNever;
            }
            set {
                this._isNever = value;
            }
        }

        public Literal Timeout {
            get {
                return this._timeout;
            }
            set {
                base.UpdateTokenInfo(value);
                this._timeout = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Timeout?.Accept(visitor);
        }
    }
}
