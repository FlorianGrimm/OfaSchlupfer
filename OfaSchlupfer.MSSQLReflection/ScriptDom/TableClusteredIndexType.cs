using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableClusteredIndexType : TableIndexType {
        private List<ColumnWithSortOrder> _columns = new List<ColumnWithSortOrder>();

        private bool _columnStore;

        public List<ColumnWithSortOrder> Columns {
            get {
                return this._columns;
            }
        }

        public bool ColumnStore {
            get {
                return this._columnStore;
            }

            set {
                this._columnStore = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
        }
    }
}
