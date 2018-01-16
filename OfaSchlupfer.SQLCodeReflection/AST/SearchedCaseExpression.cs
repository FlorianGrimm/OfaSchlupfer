namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SearchedCaseExpression : CaseExpression {
        public List<SearchedWhenClause> WhenClauses { get; } = new List<SearchedWhenClause>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.WhenClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
