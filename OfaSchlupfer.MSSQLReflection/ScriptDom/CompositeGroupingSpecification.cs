using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CompositeGroupingSpecification : GroupingSpecification {
        private List<GroupingSpecification> _items = new List<GroupingSpecification>();

        public List<GroupingSpecification> Items {
            get {
                return this._items;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Items.Count; i < count; i++) {
                this.Items[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
