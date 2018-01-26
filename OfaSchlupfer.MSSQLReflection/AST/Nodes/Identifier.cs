#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System;
    using System.Text;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public class Identifier : SqlNode {
        private const string EscapedRSquareParen = "]]";

        private const string EscapedQuote = "\"\"";

        private const string Quote = "\"";

        private const char LSquareParenChar = '[';

        private const char RSquareParenChar = ']';

        private const char QuoteChar = '"';

        internal const int MaxIdentifierLength = 128;

        private string _value;

        private ScriptDom.QuoteType _quoteType;

        public Identifier() { }

        public Identifier(ScriptDom.Identifier src) {
            this._quoteType = src.QuoteType;
            this._value = src.Value;
        }

        public string Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public ScriptDom.QuoteType QuoteType {
            get {
                return this._quoteType;
            }

            set {
                this._quoteType = value;
            }
        }

        public static string DecodeIdentifier(string identifier, out ScriptDom.QuoteType quote) {
            if (identifier != null && identifier.Length > 2) {
                if (identifier.Length != 0 && (identifier[0] == '[' || identifier[0] == '"')) {
                    string text = identifier.Substring(1, identifier.Length - 2);
                    if (identifier[0] == '[') {
                        quote = ScriptDom.QuoteType.SquareBracket;
                        return text.Replace("]]", "]");
                    }
                    quote = ScriptDom.QuoteType.DoubleQuote;
                    return text.Replace("\"\"", "\"");
                }
                quote = ScriptDom.QuoteType.NotQuoted;
                return identifier;
            }
            quote = ScriptDom.QuoteType.NotQuoted;
            return identifier;
        }

        public static string EncodeIdentifier(string identifier) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            stringBuilder.Append(identifier.Replace("]", "]]"));
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        public static string EncodeIdentifier(string identifier, ScriptDom.QuoteType quoteType) {
            StringBuilder stringBuilder = new StringBuilder();
            switch (quoteType) {
                case ScriptDom.QuoteType.NotQuoted:
                    return identifier;
                case ScriptDom.QuoteType.SquareBracket:
                    stringBuilder.Append("[");
                    stringBuilder.Append(identifier.Replace("]", "]]"));
                    stringBuilder.Append("]");
                    break;
                case ScriptDom.QuoteType.DoubleQuote:
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
            this._quoteType = ScriptDom.QuoteType.NotQuoted;
        }

        internal void SetIdentifier(string text) {
            this._value = Identifier.DecodeIdentifier(text, out this._quoteType);
        }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
