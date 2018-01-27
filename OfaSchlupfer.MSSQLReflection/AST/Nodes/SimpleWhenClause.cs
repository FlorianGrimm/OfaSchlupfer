#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SimpleWhenClause : WhenClause {
        public SimpleWhenClause() : base() { }
        public SimpleWhenClause(ScriptDom.SimpleWhenClause src) : base(src) {
            this.WhenExpression = Copier.Copy<ScalarExpression>(src.WhenExpression);
        }
        public ScalarExpression WhenExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.WhenExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
