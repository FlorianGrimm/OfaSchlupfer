using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CheckpointStatement : TSqlStatement {
        private Literal _duration;

        public Literal Duration {
            get {
                return this._duration;
            }

            set {
                this.UpdateTokenInfo(value);
                this._duration = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Duration?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
