namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExternalTableReplicatedDistributionPolicy : ExternalTableDistributionPolicy {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
