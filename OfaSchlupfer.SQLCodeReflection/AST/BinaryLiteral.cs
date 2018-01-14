namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class BinaryLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Binary;
            }
        }

        public bool IsLargeObject { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
