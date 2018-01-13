namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropBrokerPriorityStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
