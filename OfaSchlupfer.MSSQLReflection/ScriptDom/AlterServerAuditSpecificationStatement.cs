namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterServerAuditSpecificationStatement : AuditSpecificationStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
