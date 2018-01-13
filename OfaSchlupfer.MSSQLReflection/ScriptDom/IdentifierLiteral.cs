namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IdentifierLiteral : Literal {
        private QuoteType _quoteType;

        public override LiteralType LiteralType {
            get {
                return LiteralType.Identifier;
            }
        }

        public QuoteType QuoteType {
            get {
                return this._quoteType;
            }

            set {
                this._quoteType = value;
            }
        }

        internal void SetUnquotedIdentifier(string text) {
            base.Value = text;
            this._quoteType = QuoteType.NotQuoted;
        }

        internal void SetIdentifier(string text) {
            base.Value = Identifier.DecodeIdentifier(text, out this._quoteType);
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
