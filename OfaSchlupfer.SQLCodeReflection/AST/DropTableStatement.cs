namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropTableStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
