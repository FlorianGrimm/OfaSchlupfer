namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UnpivotedTableReference : TableReferenceWithAlias {
        private TableReference _tableReference;

        private List<ColumnReferenceExpression> _inColumns = new List<ColumnReferenceExpression>();

        private Identifier _pivotColumn;

        private Identifier _valueColumn;

        public TableReference TableReference {
            get {
                return this._tableReference;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableReference = value;
            }
        }

        public List<ColumnReferenceExpression> InColumns {
            get {
                return this._inColumns;
            }
        }

        public Identifier PivotColumn {
            get {
                return this._pivotColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._pivotColumn = value;
            }
        }

        public Identifier ValueColumn {
            get {
                return this._valueColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._valueColumn = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableReference?.Accept(visitor);
            for (int i = 0, count = this.InColumns.Count; i < count; i++) {
                this.InColumns[i].Accept(visitor);
            }
            this.PivotColumn?.Accept(visitor);
            this.ValueColumn?.Accept(visitor);
        }
    }
}
