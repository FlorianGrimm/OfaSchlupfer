namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class StringLiteral : Literal {
        private bool _isNational;

        private bool _isLargeObject;

        public override LiteralType LiteralType {
            get {
                return LiteralType.String;
            }
        }

        public bool IsNational {
            get {
                return this._isNational;
            }

            set {
                this._isNational = value;
            }
        }

        public bool IsLargeObject {
            get {
                return this._isLargeObject;
            }

            set {
                this._isLargeObject = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
