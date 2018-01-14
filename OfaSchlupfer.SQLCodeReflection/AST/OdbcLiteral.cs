namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class OdbcLiteral : Literal {
        private OdbcLiteralType _odbcLiteralType;

        public override LiteralType LiteralType {
            get {
                return LiteralType.Odbc;
            }
        }

        public OdbcLiteralType OdbcLiteralType {
            get {
                return this._odbcLiteralType;
            }

            set {
                this._odbcLiteralType = value;
            }
        }

        public bool IsNational { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
