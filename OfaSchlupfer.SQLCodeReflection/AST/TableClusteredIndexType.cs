namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TableClusteredIndexType : TableIndexType {
        public List<ColumnWithSortOrder> Columns { get; } = new List<ColumnWithSortOrder>();

        public bool ColumnStore { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Columns.Accept(visitor);
        }
    }
}
