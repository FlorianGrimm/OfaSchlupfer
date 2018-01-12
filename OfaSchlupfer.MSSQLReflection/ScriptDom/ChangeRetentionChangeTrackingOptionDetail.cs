using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ChangeRetentionChangeTrackingOptionDetail : ChangeTrackingOptionDetail {
        private Literal _retentionPeriod;

        private TimeUnit _unit;

        public Literal RetentionPeriod {
            get {
                return this._retentionPeriod;
            }
            set {
                base.UpdateTokenInfo(value);
                this._retentionPeriod = value;
            }
        }

        public TimeUnit Unit {
            get {
                return this._unit;
            }
            set {
                this._unit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.RetentionPeriod?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
