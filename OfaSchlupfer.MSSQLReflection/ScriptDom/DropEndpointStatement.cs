namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropEndpointStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
