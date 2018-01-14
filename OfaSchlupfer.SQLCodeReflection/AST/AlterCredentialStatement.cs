namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterCredentialStatement : CredentialStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
