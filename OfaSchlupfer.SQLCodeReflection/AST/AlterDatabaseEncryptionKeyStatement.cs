namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterDatabaseEncryptionKeyStatement : DatabaseEncryptionKeyStatement {
        public bool Regenerate { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
