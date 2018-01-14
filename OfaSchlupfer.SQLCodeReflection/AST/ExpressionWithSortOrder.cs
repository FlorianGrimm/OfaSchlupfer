namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExpressionWithSortOrder : TSqlFragment {
        private SortOrder _sortOrder;

        private ScalarExpression _expression;

        public SortOrder SortOrder {
            get {
                return this._sortOrder;
            }

            set {
                this._sortOrder = value;
            }
        }

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Expression != null) {
                this.Expression.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
