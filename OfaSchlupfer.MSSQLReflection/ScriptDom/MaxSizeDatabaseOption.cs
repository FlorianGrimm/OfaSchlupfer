using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MaxSizeDatabaseOption : DatabaseOption {
        private Literal _maxSize;

        private MemoryUnit _units;

        public Literal MaxSize {
            get {
                return this._maxSize;
            }
            set {
                base.UpdateTokenInfo(value);
                this._maxSize = value;
            }
        }

        public MemoryUnit Units {
            get {
                return this._units;
            }
            set {
                this._units = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxSize?.Accept(visitor);
        }
    }
}
