namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropAsymmetricKeyStatement : DropUnownedObjectStatement {
        public bool RemoveProviderKey { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
