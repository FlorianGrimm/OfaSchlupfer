namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OutputIntoClause : TSqlFragment {
        private TableReference _intoTable;

        public List<SelectElement> SelectColumns { get; } = new List<SelectElement>();

        public TableReference IntoTable {
            get {
                return this._intoTable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._intoTable = value;
            }
        }

        public List<ColumnReferenceExpression> IntoTableColumns { get; } = new List<ColumnReferenceExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SelectColumns.Accept(visitor);
            this.IntoTable?.Accept(visitor);
            this.IntoTableColumns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
