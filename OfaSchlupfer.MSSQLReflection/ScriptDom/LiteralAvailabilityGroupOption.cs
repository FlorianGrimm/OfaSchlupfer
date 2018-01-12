using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LiteralAvailabilityGroupOption : AvailabilityGroupOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }
}
