namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SubqueryComparisonPredicate : BooleanExpression {
        public SubqueryComparisonPredicate() : base() { }
        public SubqueryComparisonPredicate(ScriptDom.SubqueryComparisonPredicate src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.ComparisonType = src.ComparisonType;
            this.Subquery = Copier.Copy<ScalarSubquery>(src.Subquery);
            this.SubqueryComparisonPredicateType = src.SubqueryComparisonPredicateType;
        }
        public ScalarExpression Expression { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType ComparisonType { get; set; }

        public ScalarSubquery Subquery { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.SubqueryComparisonPredicateType SubqueryComparisonPredicateType { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.Subquery?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
