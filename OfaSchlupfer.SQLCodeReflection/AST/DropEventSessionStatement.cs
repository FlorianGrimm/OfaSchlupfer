namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropEventSessionStatement : DropUnownedObjectStatement {
        public EventSessionScope SessionScope { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
