namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class NullLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Null;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
