namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropColumnMasterKeyStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
