namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropDatabaseAuditSpecificationStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
