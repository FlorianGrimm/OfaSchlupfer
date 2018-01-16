namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CompositeGroupingSpecification : GroupingSpecification {
        public List<GroupingSpecification> Items { get; } = new List<GroupingSpecification>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Items.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
