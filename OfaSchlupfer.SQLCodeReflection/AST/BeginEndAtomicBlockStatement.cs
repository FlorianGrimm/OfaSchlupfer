namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class BeginEndAtomicBlockStatement : BeginEndBlockStatement {
        public List<AtomicBlockOption> Options { get; } = new List<AtomicBlockOption>();

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
