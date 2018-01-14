using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class TableClusteredIndexType : TableIndexType {
        private List<ColumnWithSortOrder> _columns = new List<ColumnWithSortOrder>();

        public List<ColumnWithSortOrder> Columns {
            get {
                return this._columns;
            }
        }

        public bool ColumnStore { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
        }
    }
}
