namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropWorkloadGroupStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
