#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ColumnWithSortOrder : SqlNode {
        public ColumnWithSortOrder() : base() { }
        public ColumnWithSortOrder(ScriptDom.ColumnWithSortOrder src) : base(src) {
            this.Column = Copier.Copy<ColumnReferenceExpression>(src.Column);
        }
        public ColumnReferenceExpression Column;
        public Microsoft.SqlServer.TransactSql.ScriptDom.SortOrder SortOrder;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
