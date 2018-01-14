namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterServerAuditSpecificationStatement : AuditSpecificationStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
