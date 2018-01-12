using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AuditGuidAuditOption : AuditOption {
        private Literal _guid;

        public Literal Guid {
            get {
                return this._guid;
            }
            set {
                base.UpdateTokenInfo(value);
                this._guid = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Guid?.Accept(visitor);
        }
    }
}
