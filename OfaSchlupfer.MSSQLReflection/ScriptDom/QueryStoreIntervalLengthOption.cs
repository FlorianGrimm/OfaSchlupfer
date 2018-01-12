using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreIntervalLengthOption : QueryStoreOption {
        private Literal _statsIntervalLength;

        public Literal StatsIntervalLength {
            get {
                return this._statsIntervalLength;
            }
            set {
                base.UpdateTokenInfo(value);
                this._statsIntervalLength = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StatsIntervalLength?.Accept(visitor);
        }
    }
}
