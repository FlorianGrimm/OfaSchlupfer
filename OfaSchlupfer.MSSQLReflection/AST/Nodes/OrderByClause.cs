#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class OrderByClause : SqlNode {
        public OrderByClause() : base() { }
        public OrderByClause(ScriptDom.OrderByClause src) : base(src) {
            Copier.CopyList(this.OrderByElements, src.OrderByElements);
        }
        public List<ExpressionWithSortOrder> OrderByElements { get; } = new List<ExpressionWithSortOrder>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OrderByElements.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
