namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropCryptographicProviderStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
