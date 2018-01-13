namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateDatabaseEncryptionKeyStatement : DatabaseEncryptionKeyStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
