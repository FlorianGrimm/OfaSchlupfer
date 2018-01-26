#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class OutputIntoClause : SqlNode {
        public OutputIntoClause() : base() { }
        public OutputIntoClause(ScriptDom.OutputIntoClause src) : base(src) {
            Copier.CopyList(this.SelectColumns, src.SelectColumns);
            this.IntoTable = Copier.Copy<TableReference>(src.IntoTable);
            Copier.CopyList(this.IntoTableColumns, src.IntoTableColumns);
        }

        public List<SelectElement> SelectColumns { get; } = new List<SelectElement>();

        public TableReference IntoTable { get; set; }
        public List<ColumnReferenceExpression> IntoTableColumns { get; } = new List<ColumnReferenceExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SelectColumns.Accept(visitor);
            this.IntoTable?.Accept(visitor);
            this.IntoTableColumns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
