using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class OutputIntoClause : TSqlFragment {
        private List<SelectElement> _selectColumns = new List<SelectElement>();

        private TableReference _intoTable;

        private List<ColumnReferenceExpression> _intoTableColumns = new List<ColumnReferenceExpression>();

        public List<SelectElement> SelectColumns {
            get {
                return this._selectColumns;
            }
        }

        public TableReference IntoTable {
            get {
                return this._intoTable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._intoTable = value;
            }
        }

        public List<ColumnReferenceExpression> IntoTableColumns {
            get {
                return this._intoTableColumns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.SelectColumns.Count; i < count; i++) {
                this.SelectColumns[i].Accept(visitor);
            }
            this.IntoTable?.Accept(visitor);
            int j = 0;
            for (int count2 = this.IntoTableColumns.Count; j < count2; j++) {
                this.IntoTableColumns[j].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
