namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OverClause : TSqlFragment {
        private OrderByClause _orderByClause;

        private WindowFrameClause _windowFrameClause;

        public List<ScalarExpression> Partitions { get; } = new List<ScalarExpression>();

        public OrderByClause OrderByClause {
            get {
                return this._orderByClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._orderByClause = value;
            }
        }

        public WindowFrameClause WindowFrameClause {
            get {
                return this._windowFrameClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._windowFrameClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Partitions.Accept(visitor);
            this.OrderByClause?.Accept(visitor);
            this.WindowFrameClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
