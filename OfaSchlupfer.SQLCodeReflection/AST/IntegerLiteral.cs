namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class IntegerLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Integer;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
