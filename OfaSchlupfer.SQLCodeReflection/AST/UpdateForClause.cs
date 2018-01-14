namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UpdateForClause : ForClause {
        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
