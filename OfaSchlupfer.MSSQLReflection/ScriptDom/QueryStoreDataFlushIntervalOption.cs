using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreDataFlushIntervalOption : QueryStoreOption {
        private Literal _flushInterval;

        public Literal FlushInterval {
            get {
                return this._flushInterval;
            }
            set {
                base.UpdateTokenInfo(value);
                this._flushInterval = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FlushInterval?.Accept(visitor);
        }
    }
}
