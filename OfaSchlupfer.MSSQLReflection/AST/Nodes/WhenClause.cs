#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class WhenClause : SqlNode {
        public WhenClause() : base() { }
        public WhenClause(ScriptDom.WhenClause src) : base(src) {
            this.ThenExpression = Copier.Copy<ScalarExpression>(src.ThenExpression);
        }
        public ScalarExpression ThenExpression;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ThenExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
