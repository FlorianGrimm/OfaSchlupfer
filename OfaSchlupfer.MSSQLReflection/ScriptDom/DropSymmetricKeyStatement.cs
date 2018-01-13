namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropSymmetricKeyStatement : DropUnownedObjectStatement {
        public bool RemoveProviderKey { get; set; }
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
