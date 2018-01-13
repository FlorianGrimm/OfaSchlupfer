namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropColumnEncryptionKeyStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
