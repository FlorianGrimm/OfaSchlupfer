using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PivotedTableReference : TableReferenceWithAlias {
        private TableReference _tableReference;

        private List<Identifier> _inColumns = new List<Identifier>();

        private ColumnReferenceExpression _pivotColumn;

        private List<ColumnReferenceExpression> _valueColumns = new List<ColumnReferenceExpression>();

        private MultiPartIdentifier _aggregateFunctionIdentifier;

        public TableReference TableReference {
            get {
                return this._tableReference;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableReference = value;
            }
        }

        public List<Identifier> InColumns {
            get {
                return this._inColumns;
            }
        }

        public ColumnReferenceExpression PivotColumn {
            get {
                return this._pivotColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._pivotColumn = value;
            }
        }

        public List<ColumnReferenceExpression> ValueColumns {
            get {
                return this._valueColumns;
            }
        }

        public MultiPartIdentifier AggregateFunctionIdentifier {
            get {
                return this._aggregateFunctionIdentifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._aggregateFunctionIdentifier = value;
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
            int j = 0;
            for (int count2 = this.ValueColumns.Count; j < count2; j++) {
                this.ValueColumns[j].Accept(visitor);
            }
            this.AggregateFunctionIdentifier?.Accept(visitor);
        }
    }
}
