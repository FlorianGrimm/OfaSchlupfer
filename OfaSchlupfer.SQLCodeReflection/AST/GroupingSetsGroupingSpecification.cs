using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class GroupingSetsGroupingSpecification : GroupingSpecification {
        private List<GroupingSpecification> _sets = new List<GroupingSpecification>();

        public List<GroupingSpecification> Sets {
            get {
                return this._sets;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Sets.Count; i < count; i++) {
                this.Sets[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
