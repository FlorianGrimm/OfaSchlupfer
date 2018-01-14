namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TSqlScript : TSqlFragment {
        public List<TSqlBatch> Batches { get; } = new List<TSqlBatch>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            var batches = this.Batches;
            for (int i = 0, count = batches.Count; i < count; i++) {
                batches[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
