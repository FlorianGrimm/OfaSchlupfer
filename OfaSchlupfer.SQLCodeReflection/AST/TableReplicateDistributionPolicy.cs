namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class TableReplicateDistributionPolicy : TableDistributionPolicy {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
