#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class TableClusteredIndexType : TableIndexType {
        public TableClusteredIndexType() : base() { }
        public TableClusteredIndexType(ScriptDom.TableClusteredIndexType src) : base(src) {
            Copier.CopyList(this.Columns, src.Columns);
            this.ColumnStore = src.ColumnStore;
        }
        public List<ColumnWithSortOrder> Columns { get; } = new List<ColumnWithSortOrder>();
        public bool ColumnStore;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Columns.Accept(visitor);
        }
    }
}
