namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UpdateForClause : ForClause {
        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
