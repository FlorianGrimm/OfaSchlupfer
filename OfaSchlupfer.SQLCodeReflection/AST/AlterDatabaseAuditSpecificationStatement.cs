namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterDatabaseAuditSpecificationStatement : AuditSpecificationStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
