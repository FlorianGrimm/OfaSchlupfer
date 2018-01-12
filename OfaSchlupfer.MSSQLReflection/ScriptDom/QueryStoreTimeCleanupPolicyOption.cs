using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreTimeCleanupPolicyOption : QueryStoreOption {
        private Literal _staleQueryThreshold;

        public Literal StaleQueryThreshold {
            get {
                return this._staleQueryThreshold;
            }
            set {
                base.UpdateTokenInfo(value);
                this._staleQueryThreshold = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StaleQueryThreshold?.Accept(visitor);
        }
    }
}
