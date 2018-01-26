#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SelectScalarExpression : SelectElement {
        public SelectScalarExpression() : base() { }
        public SelectScalarExpression(ScriptDom.SelectScalarExpression src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.ColumnName = Copier.Copy<IdentifierOrValueExpression>(src.ColumnName);
        }

        public ScalarExpression Expression { get; set; }

        public IdentifierOrValueExpression ColumnName { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.ColumnName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
