using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SearchedCaseExpression : CaseExpression {
        private List<SearchedWhenClause> _whenClauses = new List<SearchedWhenClause>();

        public List<SearchedWhenClause> WhenClauses {
            get {
                return this._whenClauses;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.WhenClauses.Count; i < count; i++) {
                this.WhenClauses[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
