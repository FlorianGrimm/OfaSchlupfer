#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ScalarSubquery : PrimaryExpression {
        public ScalarSubquery() : base() { }
        public ScalarSubquery(ScriptDom.ScalarSubquery src) : base(src) {
            this.QueryExpression = Copier.Copy<QueryExpression>(src.QueryExpression);
        }

        public QueryExpression QueryExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.QueryExpression?.Accept(visitor);
        }
    }
}
