using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class RollupGroupingSpecification : GroupingSpecification {
        private List<GroupingSpecification> _arguments = new List<GroupingSpecification>();

        public List<GroupingSpecification> Arguments {
            get {
                return this._arguments;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Arguments.Count; i < count; i++) {
                this.Arguments[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
