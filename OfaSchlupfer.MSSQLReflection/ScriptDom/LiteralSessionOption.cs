using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LiteralSessionOption : SessionOption {
        private Literal _value;

        private MemoryUnit _unit;

        public Literal Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
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
            this.Value?.Accept(visitor);
        }
    }
}
