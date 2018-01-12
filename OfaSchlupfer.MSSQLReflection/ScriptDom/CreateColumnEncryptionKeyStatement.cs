namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateColumnEncryptionKeyStatement : ColumnEncryptionKeyStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
