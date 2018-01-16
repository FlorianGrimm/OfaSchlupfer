namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class GroupingSetsGroupingSpecification : GroupingSpecification {
        public List<GroupingSpecification> Sets { get; } = new List<GroupingSpecification>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Sets.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
