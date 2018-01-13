using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OrderByClause : TSqlFragment {
        private List<ExpressionWithSortOrder> _orderByElements = new List<ExpressionWithSortOrder>();

        public List<ExpressionWithSortOrder> OrderByElements {
            get {
                return this._orderByElements;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.OrderByElements.Count; i < count; i++) {
                this.OrderByElements[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
