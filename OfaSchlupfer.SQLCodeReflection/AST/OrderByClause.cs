namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OrderByClause : TSqlFragment {
        public List<ExpressionWithSortOrder> OrderByElements { get; } = new List<ExpressionWithSortOrder>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OrderByElements.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
