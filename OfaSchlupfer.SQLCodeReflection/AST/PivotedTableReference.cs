namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class PivotedTableReference : TableReferenceWithAlias {
        private TableReference _tableReference;

        private ColumnReferenceExpression _pivotColumn;

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

        public List<Identifier> InColumns { get; } = new List<Identifier>();

        public ColumnReferenceExpression PivotColumn {
            get {
                return this._pivotColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._pivotColumn = value;
            }
        }

        public List<ColumnReferenceExpression> ValueColumns { get; } = new List<ColumnReferenceExpression>();

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
            this.InColumns.Accept(visitor);
            this.PivotColumn?.Accept(visitor);
            this.ValueColumns.Accept(visitor);
            this.AggregateFunctionIdentifier?.Accept(visitor);
        }
    }
}
