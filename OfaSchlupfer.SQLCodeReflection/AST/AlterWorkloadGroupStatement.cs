namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterWorkloadGroupStatement : WorkloadGroupStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
