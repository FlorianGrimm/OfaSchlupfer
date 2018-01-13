namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropServerAuditSpecificationStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
