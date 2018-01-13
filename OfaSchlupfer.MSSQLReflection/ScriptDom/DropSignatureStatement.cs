namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropSignatureStatement : SignatureStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
