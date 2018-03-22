#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class WithinGroupClause : SqlNode {
        public WithinGroupClause() : base() { }
        public WithinGroupClause(ScriptDom.WithinGroupClause src) : base(src) {
            this.OrderByClause = Copier.Copy<OrderByClause>(src.OrderByClause);
        }
        public OrderByClause OrderByClause;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OrderByClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
