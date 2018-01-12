using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class QueryExpression : TSqlFragment {
        private OrderByClause _orderByClause;

        private OffsetClause _offsetClause;

        private ForClause _forClause;

        public OrderByClause OrderByClause {
            get {
                return this._orderByClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._orderByClause = value;
            }
        }

        public OffsetClause OffsetClause {
            get {
                return this._offsetClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._offsetClause = value;
            }
        }

        public ForClause ForClause {
            get {
                return this._forClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._forClause = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OrderByClause?.Accept(visitor);
            this.OffsetClause?.Accept(visitor);
            this.ForClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
