using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreMaxPlansPerQueryOption : QueryStoreOption {
        private Literal _maxPlansPerQuery;

        public Literal MaxPlansPerQuery {
            get {
                return this._maxPlansPerQuery;
            }
            set {
                base.UpdateTokenInfo(value);
                this._maxPlansPerQuery = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxPlansPerQuery?.Accept(visitor);
        }
    }
}
