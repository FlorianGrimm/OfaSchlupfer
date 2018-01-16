namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class BeginEndAtomicBlockStatement : BeginEndBlockStatement {
        public List<AtomicBlockOption> Options { get; } = new List<AtomicBlockOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Options.Accept(visitor);
        }
    }
}
