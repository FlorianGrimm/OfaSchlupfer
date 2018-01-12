namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropServerAuditStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
