using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MaxDurationOption : IndexOption {
        private Literal _maxDuration;

        private TimeUnit? _unit;

        public Literal MaxDuration {
            get {
                return this._maxDuration;
            }
            set {
                base.UpdateTokenInfo(value);
                this._maxDuration = value;
            }
        }

        public TimeUnit? Unit {
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
            this.MaxDuration?.Accept(visitor);
        }
    }
}
