using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MaxDispatchLatencySessionOption : SessionOption {
        private bool _isInfinite;

        private Literal _value;

        public bool IsInfinite {
            get {
                return this._isInfinite;
            }
            set {
                this._isInfinite = value;
            }
        }

        public Literal Value {
            get {
                return this._value;
            }
            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
