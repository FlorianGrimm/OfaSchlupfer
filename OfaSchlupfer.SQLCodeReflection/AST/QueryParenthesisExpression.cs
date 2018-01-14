namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class QueryParenthesisExpression : QueryExpression {
        private QueryExpression _queryExpression;

        public QueryExpression QueryExpression {
            get {
                return this._queryExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._queryExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.QueryExpression?.Accept(visitor);
        }
    }
}
