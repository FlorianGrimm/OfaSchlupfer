namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropServiceStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
