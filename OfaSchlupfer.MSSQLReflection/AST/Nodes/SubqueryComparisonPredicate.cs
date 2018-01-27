#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SubqueryComparisonPredicate : BooleanExpression {
        public SubqueryComparisonPredicate() : base() { }
        public SubqueryComparisonPredicate(ScriptDom.SubqueryComparisonPredicate src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.ComparisonType = src.ComparisonType;
            this.Subquery = Copier.Copy<ScalarSubquery>(src.Subquery);
            this.SubqueryComparisonPredicateType = src.SubqueryComparisonPredicateType;
        }
        public ScalarExpression Expression;
        public Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType ComparisonType;
        public ScalarSubquery Subquery;
        public Microsoft.SqlServer.TransactSql.ScriptDom.SubqueryComparisonPredicateType SubqueryComparisonPredicateType;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.Subquery?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
