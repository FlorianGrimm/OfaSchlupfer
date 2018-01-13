namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateServerAuditStatement : ServerAuditStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
