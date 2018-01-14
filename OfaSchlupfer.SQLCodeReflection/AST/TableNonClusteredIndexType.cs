namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class TableNonClusteredIndexType : TableIndexType {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
