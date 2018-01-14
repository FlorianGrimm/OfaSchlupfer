using antlr;
using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    internal class TSqlWhitespaceTokenFilter : TokenStream {
        internal class TSqlParserTokenProxyWithIndex : IToken {
            private IToken _token;

            private int _index;

            public TSqlParserToken Token {
                get {
                    return (TSqlParserToken)this._token;
                }
            }

            public int TokenIndex {
                get {
                    return this._index;
                }
            }

            public int Type {
                get {
                    return this._token.Type;
                }
                set {
                    this._token.Type = value;
                }
            }

            public TSqlParserTokenProxyWithIndex(TSqlParserToken token, int index) {
                this._token = token;
                this._index = index;
            }

            public int getColumn() {
                return this._token.getColumn();
            }

            public void setColumn(int c) {
                this._token.setColumn(c);
            }

            public int getLine() {
                return this._token.getLine();
            }

            public void setLine(int l) {
                this._token.setLine(l);
            }

            public string getFilename() {
                return this._token.getFilename();
            }

            public void setFilename(string name) {
                this._token.setFilename(name);
            }

            public string getText() {
                return this._token.getText();
            }

            public void setText(string t) {
                this._token.setText(t);
            }
        }

        private bool _quotedIdentifier;

        private IList<TSqlParserToken> _streamToFilter;

        private int _currentTokenIndex;

        private int _streamLength;

        private TSqlParserToken _lastToken;

        public TSqlParserToken LastToken {
            get {
                return this._lastToken;
            }
        }

        public bool QuotedIdentifier {
            get {
                return this._quotedIdentifier;
            }

            set {
                this._quotedIdentifier = value;
            }
        }

        public TSqlWhitespaceTokenFilter(bool quotedIdentifier, IList<TSqlParserToken> streamToFilter) {
            this._quotedIdentifier = quotedIdentifier;
            this._streamToFilter = streamToFilter;
            this._currentTokenIndex = 0;
            if (streamToFilter.Count > 0) {
                this._lastToken = streamToFilter[0];
            } else {
                this._lastToken = new TSqlParserToken(TSqlTokenType.EndOfFile, null);
            }
            this._streamLength = streamToFilter.Count;
        }

        public IToken nextToken() {
            TSqlParserToken tSqlParserToken = null;
            int index = -1;
            while (this._currentTokenIndex < this._streamLength) {
                tSqlParserToken = this._streamToFilter[this._currentTokenIndex];
                index = this._currentTokenIndex;
                this._currentTokenIndex++;
                if (tSqlParserToken.TokenType != TSqlTokenType.SingleLineComment && tSqlParserToken.TokenType != TSqlTokenType.MultilineComment && tSqlParserToken.TokenType != TSqlTokenType.WhiteSpace) {
                    break;
                }
            }
            if (tSqlParserToken == null) {
                if (this._streamLength != 0) {
                    TSqlParserToken tSqlParserToken2 = this._streamToFilter[this._streamToFilter.Count - 1];
                    int num = (tSqlParserToken2.Text != null) ? tSqlParserToken2.Text.Length : 0;
                    tSqlParserToken = new TSqlParserToken(TSqlTokenType.EndOfFile, tSqlParserToken2.Offset + num, null, tSqlParserToken2.Line, tSqlParserToken2.Column + num);
                } else {
                    tSqlParserToken = new TSqlParserToken(TSqlTokenType.EndOfFile, null);
                }
            } else if (tSqlParserToken.TokenType == TSqlTokenType.AsciiStringOrQuotedIdentifier) {
                tSqlParserToken.ConvertStringToIdentifier = this._quotedIdentifier;
            }
            this._lastToken = tSqlParserToken;
            return new TSqlParserTokenProxyWithIndex(tSqlParserToken, index);
        }
    }
}
