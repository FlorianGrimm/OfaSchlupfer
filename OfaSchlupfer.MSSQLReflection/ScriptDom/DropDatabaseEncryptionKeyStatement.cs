namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropDatabaseEncryptionKeyStatement : TSqlStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
