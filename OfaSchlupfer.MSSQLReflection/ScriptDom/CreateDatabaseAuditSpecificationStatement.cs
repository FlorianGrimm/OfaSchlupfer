namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateDatabaseAuditSpecificationStatement : AuditSpecificationStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
