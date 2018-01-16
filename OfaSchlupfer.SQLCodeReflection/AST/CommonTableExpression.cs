namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CommonTableExpression : TSqlFragment {
        private Identifier _expressionName;

        private QueryExpression _queryExpression;

        public Identifier ExpressionName {
            get {
                return this._expressionName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expressionName = value;
            }
        }

        public List<Identifier> Columns { get; } = new List<Identifier>();

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
            this.ExpressionName?.Accept(visitor);
            this.Columns.Accept(visitor);
            this.QueryExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
