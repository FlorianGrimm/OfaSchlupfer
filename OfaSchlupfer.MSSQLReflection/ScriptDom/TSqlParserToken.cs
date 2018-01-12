using antlr;

namespace OfaSchlupfer.ScriptDom {
    public sealed class TSqlParserToken : IToken {
        private string _text;

        private int _offset;

        private int _line;

        private int _column;

        private TSqlTokenType _tokenType;

        private bool _convertStringToIdentifier;

        public TSqlTokenType TokenType {
            get {
                return this._tokenType;
            }
            set {
                this._tokenType = value;
            }
        }

        internal bool ConvertStringToIdentifier {
            get {
                return this._convertStringToIdentifier;
            }
            set {
                this._convertStringToIdentifier = value;
            }
        }

        public int Offset {
            get {
                return this._offset;
            }
            set {
                this._offset = value;
            }
        }

        public int Line {
            get {
                return this._line;
            }
            set {
                this._line = value;
            }
        }

        public int Column {
            get {
                return this._column;
            }
            set {
                this._column = value;
            }
        }

        public string Text {
            get {
                return this._text;
            }
            set {
                this._text = value;
            }
        }

        int IToken.Type {
            get {
                if (this._tokenType == TSqlTokenType.AsciiStringOrQuotedIdentifier) {
                    if (this._convertStringToIdentifier) {
                        return 233;
                    }
                    return 230;
                }
                return (int)this._tokenType;
            }
            set {
                if (this._tokenType != TSqlTokenType.AsciiStringOrQuotedIdentifier) {
                    this._tokenType = (TSqlTokenType)value;
                }
            }
        }

        public TSqlParserToken()
            : this(TSqlTokenType.None, 0, null, 1, 1) {
        }

        public TSqlParserToken(TSqlTokenType type, string text)
            : this(type, 0, text, 1, 1) {
        }

        public TSqlParserToken(TSqlTokenType type, int offset, string text, int line, int column) {
            this._text = text;
            this._tokenType = type;
            this._offset = offset;
            this._line = line;
            this._column = column;
        }

        public bool IsKeyword() {
            if (this.TokenType > TSqlTokenType.EndOfFile) {
                return this.TokenType < TSqlTokenType.Bang;
            }
            return false;
        }

        int IToken.getColumn() {
            return this._column;
        }

        void IToken.setColumn(int c) {
            this._column = c;
        }

        int IToken.getLine() {
            return this._line;
        }

        void IToken.setLine(int l) {
            this._line = l;
        }

        string IToken.getFilename() {
            return null;
        }

        void IToken.setFilename(string name) {
        }

        string IToken.getText() {
            return this.Text;
        }

        void IToken.setText(string t) {
            this.Text = t;
        }
    }
}
