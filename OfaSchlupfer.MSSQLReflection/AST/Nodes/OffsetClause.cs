#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class OffsetClause : SqlNode {
        public OffsetClause() : base() { }
        public OffsetClause(ScriptDom.OffsetClause src) : base(src) {
            this.OffsetExpression = Copier.Copy<ScalarExpression>(src.OffsetExpression);
            this.FetchExpression = Copier.Copy<ScalarExpression>(src.FetchExpression);
        }

        public ScalarExpression OffsetExpression { get; set; }

        public ScalarExpression FetchExpression { get; set; }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OffsetExpression?.Accept(visitor);
            this.FetchExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
