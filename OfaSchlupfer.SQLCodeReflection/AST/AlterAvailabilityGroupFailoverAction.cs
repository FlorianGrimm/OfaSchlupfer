namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterAvailabilityGroupFailoverAction : AlterAvailabilityGroupAction {
        public List<AlterAvailabilityGroupFailoverOption> Options { get; } = new List<AlterAvailabilityGroupFailoverOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Options.Accept(visitor);
        }
    }
}
