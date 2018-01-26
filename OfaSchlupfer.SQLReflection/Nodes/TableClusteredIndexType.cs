namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TableClusteredIndexType : TableIndexType {
        public TableClusteredIndexType() : base() { }
        public TableClusteredIndexType(ScriptDom.TableClusteredIndexType src) : base(src) {
            Copier.CopyList(this.Columns, src.Columns);
            this.ColumnStore = src.ColumnStore;
        }
        public List<ColumnWithSortOrder> Columns { get; } = new List<ColumnWithSortOrder>();

        public bool ColumnStore { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Columns.Accept(visitor);
        }
    }
}
