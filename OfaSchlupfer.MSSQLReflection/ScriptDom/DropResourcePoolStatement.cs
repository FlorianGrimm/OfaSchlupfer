namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropResourcePoolStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
