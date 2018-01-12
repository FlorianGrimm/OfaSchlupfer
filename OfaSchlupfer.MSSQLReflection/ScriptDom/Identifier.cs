namespace OfaSchlupfer.ScriptDom {
    using System;
    using System.Text;

    [System.Serializable]
    public /**/ class Identifier : TSqlFragment {
        private const string EscapedRSquareParen = "]]";

        private const string EscapedQuote = "\"\"";

        private const string Quote = "\"";

        private const char LSquareParenChar = '[';

        private const char RSquareParenChar = ']';

        private const char QuoteChar = '"';

        internal const int MaxIdentifierLength = 128;

        private string _value;

        private QuoteType _quoteType;

        public string Value {
            get {
                return this._value;
            }
            set {
                this._value = value;
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

        public static string DecodeIdentifier(string identifier, out QuoteType quote) {
            if (identifier != null && identifier.Length > 2) {
                if (identifier.Length != 0 && (identifier[0] == '[' || identifier[0] == '"')) {
                    string text = identifier.Substring(1, identifier.Length - 2);
                    if (identifier[0] == '[') {
                        quote = QuoteType.SquareBracket;
                        return text.Replace("]]", "]");
                    }
                    quote = QuoteType.DoubleQuote;
                    return text.Replace("\"\"", "\"");
                }
                quote = QuoteType.NotQuoted;
                return identifier;
            }
            quote = QuoteType.NotQuoted;
            return identifier;
        }

        public static string EncodeIdentifier(string identifier) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            stringBuilder.Append(identifier.Replace("]", "]]"));
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        public static string EncodeIdentifier(string identifier, QuoteType quoteType) {
            StringBuilder stringBuilder = new StringBuilder();
            switch (quoteType) {
                case QuoteType.NotQuoted:
                    return identifier;
                case QuoteType.SquareBracket:
                    stringBuilder.Append("[");
                    stringBuilder.Append(identifier.Replace("]", "]]"));
                    stringBuilder.Append("]");
                    break;
                case QuoteType.DoubleQuote:
                    stringBuilder.Append("\"");
                    stringBuilder.Append(identifier.Replace("\"", "\"\""));
                    stringBuilder.Append("\"");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("quoteType");
            }
            return stringBuilder.ToString();
        }

        internal void SetUnquotedIdentifier(string text) {
            this._value = text;
            this._quoteType = QuoteType.NotQuoted;
        }

        internal void SetIdentifier(string text) {
            this._value = Identifier.DecodeIdentifier(text, out this._quoteType);
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
