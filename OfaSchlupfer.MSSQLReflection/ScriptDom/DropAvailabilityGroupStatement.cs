namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropAvailabilityGroupStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
