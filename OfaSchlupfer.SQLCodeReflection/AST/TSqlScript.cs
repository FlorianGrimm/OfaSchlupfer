namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TSqlScript : TSqlFragment {
        public List<TSqlBatch> Batches { get; } = new List<TSqlBatch>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Batches.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
