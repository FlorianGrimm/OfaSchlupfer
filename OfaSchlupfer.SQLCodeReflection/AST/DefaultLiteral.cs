namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DefaultLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Default;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
