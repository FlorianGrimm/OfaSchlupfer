namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropPartitionSchemeStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
