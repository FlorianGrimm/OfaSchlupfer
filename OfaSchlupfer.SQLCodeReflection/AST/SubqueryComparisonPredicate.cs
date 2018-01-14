namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SubqueryComparisonPredicate : BooleanExpression {
        private ScalarExpression _expression;

        private BooleanComparisonType _comparisonType;

        private ScalarSubquery _subquery;

        private SubqueryComparisonPredicateType _subqueryComparisonPredicateType;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public BooleanComparisonType ComparisonType {
            get {
                return this._comparisonType;
            }

            set {
                this._comparisonType = value;
            }
        }

        public ScalarSubquery Subquery {
            get {
                return this._subquery;
            }

            set {
                this.UpdateTokenInfo(value);
                this._subquery = value;
            }
        }

        public SubqueryComparisonPredicateType SubqueryComparisonPredicateType {
            get {
                return this._subqueryComparisonPredicateType;
            }

            set {
                this._subqueryComparisonPredicateType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.Subquery?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
