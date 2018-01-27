#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExistsPredicate : BooleanExpression {
        public ExistsPredicate() : base() { }
        public ExistsPredicate(ScriptDom.ExistsPredicate src) : base(src) {
            this.Subquery = Copier.Copy<ScalarSubquery>(src.Subquery);
        }
        public ScalarSubquery Subquery;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Subquery?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
