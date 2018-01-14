namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterUserStatement : UserStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
