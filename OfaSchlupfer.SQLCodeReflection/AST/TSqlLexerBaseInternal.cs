using antlr;
using System.Globalization;
using System.IO;

namespace OfaSchlupfer.AST {
    internal abstract class TSqlLexerBaseInternal : CharScanner {
        protected enum TokenKind {
            Common,
            String,
            SqlCommandIdentifier,
            QuotedIdentifier,
            MultiLineComment
        }

        private int _complexTokenStartOffset;

        protected int _currentLineStartOffset;

        protected int _acceptableGoOffset;

        public int CurrentOffset {
            get {
                return this._currentLineStartOffset + this.getColumn() - 1;
            }
        }

        protected TSqlLexerBaseInternal(LexerSharedInputState state)
            : base(state) {
        }

        public void InitializeForNewInput(int startOffset, int startLine, int startColumn, TextReader input) {
            this.setTabSize(1);
            base.resetState(input);
            this.setColumn(startColumn);
            this.setLine(startLine);
            this._currentLineStartOffset = startOffset - (startColumn - 1);
            this._acceptableGoOffset = startOffset;
        }

        public override void newline() {
            this._currentLineStartOffset += this.getColumn() - 1;
            base.newline();
        }

        protected internal override IToken makeToken(int t) {
            return new TSqlParserToken((TSqlTokenType)t, this.CurrentOffset - base.text.Length, null, base.inputState.tokenStartLine, base.inputState.tokenStartColumn);
        }

        protected void checkEOF(TokenKind currentToken) {
            if (this.LA(1) != CharScanner.EOF_CHAR) {
                return;
            }
            this.uponEOF();
            ParseError parseError = null;
            switch (currentToken) {
                case TokenKind.MultiLineComment:
                    parseError = TSql80ParserBaseInternal.CreateParseError("SQL46032", this.CurrentOffset, this.getLine(), this.getColumn(), TSqlParserResource.SQL46032Message);
                    break;
                case TokenKind.QuotedIdentifier:
                    parseError = TSql80ParserBaseInternal.CreateParseError("SQL46031", this._complexTokenStartOffset, base.inputState.tokenStartLine, base.inputState.tokenStartColumn, TSqlParserResource.SQL46031Message, this.getText().TrimEnd(CharScanner.EOF_CHAR));
                    break;
                case TokenKind.SqlCommandIdentifier:
                    parseError = TSql80ParserBaseInternal.CreateParseError("SQL46033", this._complexTokenStartOffset, base.inputState.tokenStartLine, base.inputState.tokenStartColumn, TSqlParserResource.SQL46033Message, this.getText().TrimEnd(CharScanner.EOF_CHAR));
                    break;
                case TokenKind.String:
                    parseError = TSql80ParserBaseInternal.CreateParseError("SQL46030", this._complexTokenStartOffset, base.inputState.tokenStartLine, base.inputState.tokenStartColumn, TSqlParserResource.SQL46030Message, this.getText().TrimEnd(CharScanner.EOF_CHAR));
                    break;
            }
            if (parseError == null) {
                return;
            }
            throw new TSqlParseErrorException(parseError);
        }

        protected void beginComplexToken() {
            this._complexTokenStartOffset = this.CurrentOffset;
        }

        internal static bool IsValueTooLargeForTokenInteger(string source) {
            int length = source.Length;
            if (length > 11) {
                return true;
            }
            if (length >= 10) {
                long num = long.Parse(source, CultureInfo.InvariantCulture.NumberFormat);
                return num > 2147483647;
            }
            return false;
        }
    }
}
