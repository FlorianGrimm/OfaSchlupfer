namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateServerAuditSpecificationStatement : AuditSpecificationStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
