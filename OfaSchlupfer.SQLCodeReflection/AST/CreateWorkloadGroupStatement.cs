namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateWorkloadGroupStatement : WorkloadGroupStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
