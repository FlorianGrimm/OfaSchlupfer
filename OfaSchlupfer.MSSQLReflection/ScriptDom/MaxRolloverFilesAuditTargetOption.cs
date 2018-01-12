using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MaxRolloverFilesAuditTargetOption : AuditTargetOption {
        private Literal _value;

        private bool _isUnlimited;

        public Literal Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public bool IsUnlimited {
            get {
                return this._isUnlimited;
            }
            set {
                this._isUnlimited = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }
}
