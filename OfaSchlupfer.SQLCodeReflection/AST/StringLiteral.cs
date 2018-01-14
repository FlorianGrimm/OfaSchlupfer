namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class StringLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.String;
            }
        }

        public bool IsNational { get; set; }

        public bool IsLargeObject { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
