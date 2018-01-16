namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class RollupGroupingSpecification : GroupingSpecification {
        public List<GroupingSpecification> Arguments { get; } = new List<GroupingSpecification>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Arguments.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
