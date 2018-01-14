namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropPartitionFunctionStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
