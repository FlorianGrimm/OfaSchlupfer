namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropExternalResourcePoolStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
