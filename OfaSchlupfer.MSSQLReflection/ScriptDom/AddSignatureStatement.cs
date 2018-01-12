namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AddSignatureStatement : SignatureStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
