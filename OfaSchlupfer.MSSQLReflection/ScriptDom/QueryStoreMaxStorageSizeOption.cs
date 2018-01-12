using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreMaxStorageSizeOption : QueryStoreOption {
        private Literal _maxQdsSize;

        public Literal MaxQdsSize {
            get {
                return this._maxQdsSize;
            }
            set {
                base.UpdateTokenInfo(value);
                this._maxQdsSize = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxQdsSize?.Accept(visitor);
        }
    }
}
