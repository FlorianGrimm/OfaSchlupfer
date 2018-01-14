namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class WithinGroupClause : TSqlFragment {
        private OrderByClause _orderByClause;

        public OrderByClause OrderByClause {
            get {
                return this._orderByClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._orderByClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OrderByClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
