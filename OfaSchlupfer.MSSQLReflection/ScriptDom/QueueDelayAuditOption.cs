using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueueDelayAuditOption : AuditOption {
        private Literal _delay;

        public Literal Delay {
            get {
                return this._delay;
            }
            set {
                base.UpdateTokenInfo(value);
                this._delay = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Delay?.Accept(visitor);
        }
    }
}
