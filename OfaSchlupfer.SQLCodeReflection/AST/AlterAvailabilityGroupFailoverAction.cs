namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterAvailabilityGroupFailoverAction : AlterAvailabilityGroupAction {
        public List<AlterAvailabilityGroupFailoverOption> Options { get; } = new List<AlterAvailabilityGroupFailoverOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var options = this.Options;
            for (int i = 0, count = options.Count; i < count; i++) {
                options[i].Accept(visitor);
            }
        }
    }
}
