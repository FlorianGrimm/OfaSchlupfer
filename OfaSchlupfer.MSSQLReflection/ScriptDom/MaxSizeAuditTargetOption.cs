using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MaxSizeAuditTargetOption : AuditTargetOption {
        private bool _isUnlimited;

        private Literal _size;

        private MemoryUnit _unit;

        public bool IsUnlimited {
            get {
                return this._isUnlimited;
            }
            set {
                this._isUnlimited = value;
            }
        }

        public Literal Size {
            get {
                return this._size;
            }
            set {
                base.UpdateTokenInfo(value);
                this._size = value;
            }
        }

        public MemoryUnit Unit {
            get {
                return this._unit;
            }
            set {
                this._unit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Size?.Accept(visitor);
        }
    }
}
