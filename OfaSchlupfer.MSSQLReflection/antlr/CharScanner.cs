#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented
#pragma warning disable SA1310 // Field names must not contain underscore
#pragma warning disable SA1131 // Use readable conditions
#pragma warning disable SA1024 // Colons Must Be Spaced Correctly

namespace antlr {
    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using antlr.collections.impl;

    internal abstract class CharScanner : TokenStream {
        private class ReflectionBasedTokenCreator : TokenCreator {
            private string _tokenTypeName;

            private Type _tokenTypeObject;

            public override string TokenTypeName {
                get {
                    return this._tokenTypeName;
                }
            }

            public ReflectionBasedTokenCreator(string tokenTypeName) {
                this.SetTokenType(tokenTypeName);
            }

            private void SetTokenType(string tokenTypeName) {
                this._tokenTypeName = tokenTypeName;
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly assembly in assemblies) {
                    try {
                        this._tokenTypeObject = assembly.GetType(tokenTypeName);
                        if (!(this._tokenTypeObject != (Type)null)) {
                            goto end_IL_001a;
                        }
                        break;
                        end_IL_001a:;
                    } catch {
                        throw new TypeLoadException("Unable to load Type for Token class '" + tokenTypeName + "'");
                    }
                }
                if (!(this._tokenTypeObject == (Type)null)) {
                    return;
                }
                throw new TypeLoadException("Unable to load Type for Token class '" + tokenTypeName + "'");
            }

            public override IToken Create() {
                return (Token)Activator.CreateInstance(this._tokenTypeObject);
            }
        }

        internal const char NO_CHAR = '\0';

        public static readonly char EOF_CHAR = '\uffff';

        internal static readonly object EnterRuleEventKey = new object();

        internal static readonly object ExitRuleEventKey = new object();

        internal static readonly object DoneEventKey = new object();

        internal static readonly object ReportErrorEventKey = new object();

        internal static readonly object ReportWarningEventKey = new object();

        internal static readonly object NewLineEventKey = new object();

        internal static readonly object MatchEventKey = new object();

        internal static readonly object MatchNotEventKey = new object();

        internal static readonly object MisMatchEventKey = new object();

        internal static readonly object MisMatchNotEventKey = new object();

        internal static readonly object ConsumeEventKey = new object();

        internal static readonly object LAEventKey = new object();

        internal static readonly object SemPredEvaluatedEventKey = new object();

        internal static readonly object SynPredStartedEventKey = new object();

        internal static readonly object SynPredFailedEventKey = new object();

        internal static readonly object SynPredSucceededEventKey = new object();

        protected internal StringBuilder text;

        protected bool saveConsumedInput = true;

        protected TokenCreator tokenCreator;

        protected char cached_LA1;

        protected char cached_LA2;

        protected bool caseSensitive = true;

        protected bool caseSensitiveLiterals = true;

        protected Hashtable literals;

        protected internal int tabsize = 8;

        protected internal IToken returnToken_;

        protected internal LexerSharedInputState inputState;

        protected internal bool commitToPath;

        protected internal int traceDepth;

        public CharScanner() {
            this.text = new StringBuilder();
            this.setTokenCreator(new CommonToken.CommonTokenCreator());
        }

        public CharScanner(InputBuffer cb)
            : this() {
            this.inputState = new LexerSharedInputState(cb);
            this.cached_LA2 = this.inputState.input.LA(2);
            this.cached_LA1 = this.inputState.input.LA(1);
        }

        public CharScanner(LexerSharedInputState sharedState)
            : this() {
            this.inputState = sharedState;
            if (this.inputState != null) {
                this.cached_LA2 = this.inputState.input.LA(2);
                this.cached_LA1 = this.inputState.input.LA(1);
            }
        }

        public virtual IToken nextToken() {
            return null;
        }

        public virtual void append(char c) {
            if (this.saveConsumedInput) {
                this.text.Append(c);
            }
        }

        public virtual void append(string s) {
            if (this.saveConsumedInput) {
                this.text.Append(s);
            }
        }

        public virtual void commit() {
            this.inputState.input.commit();
        }

        public virtual void consume() {
            if (this.inputState.guessing == 0) {
                if (this.caseSensitive) {
                    this.append(this.cached_LA1);
                } else {
                    this.append(this.inputState.input.LA(1));
                }
                if (this.cached_LA1 == '\t') {
                    this.tab();
                } else {
                    this.inputState.column++;
                }
            }
            if (this.caseSensitive) {
                this.cached_LA1 = this.inputState.input.consume();
                this.cached_LA2 = this.inputState.input.LA(2);
            } else {
                this.cached_LA1 = this.toLower(this.inputState.input.consume());
                this.cached_LA2 = this.toLower(this.inputState.input.LA(2));
            }
        }

        public virtual void consumeUntil(int c) {
            while (CharScanner.EOF_CHAR != this.cached_LA1 && c != this.cached_LA1) {
                this.consume();
            }
        }

        public virtual void consumeUntil(BitSet bset) {
            while (this.cached_LA1 != CharScanner.EOF_CHAR && !bset.member(this.cached_LA1)) {
                this.consume();
            }
        }

        public virtual bool getCaseSensitive() {
            return this.caseSensitive;
        }

        public bool getCaseSensitiveLiterals() {
            return this.caseSensitiveLiterals;
        }

        public virtual int getColumn() {
            return this.inputState.column;
        }

        public virtual void setColumn(int c) {
            this.inputState.column = c;
        }

        public virtual bool getCommitToPath() {
            return this.commitToPath;
        }

        public virtual string getFilename() {
            return this.inputState.filename;
        }

        public virtual InputBuffer getInputBuffer() {
            return this.inputState.input;
        }

        public virtual LexerSharedInputState getInputState() {
            return this.inputState;
        }

        public virtual void setInputState(LexerSharedInputState state) {
            this.inputState = state;
        }

        public virtual int getLine() {
            return this.inputState.line;
        }

        public virtual string getText() {
            return this.text.ToString();
        }

        public virtual IToken getTokenObject() {
            return this.returnToken_;
        }

        public virtual char LA(int i) {
            switch (i) {
                case 1:
                    return this.cached_LA1;
                case 2:
                    return this.cached_LA2;
                default:
                    if (this.caseSensitive) {
                        return this.inputState.input.LA(i);
                    }
                    return this.toLower(this.inputState.input.LA(i));
            }
        }

        protected internal virtual IToken makeToken(int t) {
            IToken token = null;
            bool flag;
            try {
                token = this.tokenCreator.Create();
                if (token != null) {
                    token.Type = t;
                    token.setColumn(this.inputState.tokenStartColumn);
                    token.setLine(this.inputState.tokenStartLine);
                    token.setFilename(this.inputState.filename);
                }
                flag = true;
            } catch {
                flag = false;
            }
            if (!flag) {
                this.panic("Can't create Token object '" + this.tokenCreator.TokenTypeName + "'");
                token = Token.badToken;
            }
            return token;
        }

        public virtual int mark() {
            return this.inputState.input.mark();
        }

        public virtual void match(char c) {
            this.match((int)c);
        }

        public virtual void match(int c) {
            if (this.cached_LA1 != c) {
                throw new MismatchedCharException(this.cached_LA1, Convert.ToChar(c), false, this);
            }
            this.consume();
        }

        public virtual void match(BitSet b) {
            if (!b.member(this.cached_LA1)) {
                throw new MismatchedCharException(this.cached_LA1, b, false, this);
            }
            this.consume();
        }

        public virtual void match(string s) {
            int length = s.Length;
            int num = 0;
            while (true) {
                if (num < length) {
                    if (this.cached_LA1 == s[num]) {
                        this.consume();
                        num++;
                        continue;
                    }
                    break;
                }
                return;
            }
            throw new MismatchedCharException(this.cached_LA1, s[num], false, this);
        }

        public virtual void matchNot(char c) {
            this.matchNot((int)c);
        }

        public virtual void matchNot(int c) {
            if (this.cached_LA1 == c) {
                throw new MismatchedCharException(this.cached_LA1, Convert.ToChar(c), true, this);
            }
            this.consume();
        }

        public virtual void matchRange(int c1, int c2) {
            if (this.cached_LA1 >= c1 && this.cached_LA1 <= c2) {
                this.consume();
                return;
            }
            throw new MismatchedCharException(this.cached_LA1, Convert.ToChar(c1), Convert.ToChar(c2), false, this);
        }

        public virtual void matchRange(char c1, char c2) {
            this.matchRange((int)c1, (int)c2);
        }

        public virtual void newline() {
            this.inputState.line++;
            this.inputState.column = 1;
        }

        public virtual void tab() {
            int column = this.getColumn();
            int column2 = ((((column - 1) / this.tabsize) + 1) * this.tabsize) + 1;
            this.setColumn(column2);
        }

        public virtual void setTabSize(int size) {
            this.tabsize = size;
        }

        public virtual int getTabSize() {
            return this.tabsize;
        }

        public virtual void panic() {
            this.panic(string.Empty);
        }

        public virtual void panic(string s) {
            throw new ANTLRPanicException("CharScanner::panic: " + s);
        }

        public virtual void reportError(RecognitionException ex) {
            Console.Error.WriteLine(ex);
        }

        public virtual void reportError(string s) {
            if (this.getFilename() == null) {
                Console.Error.WriteLine("error: " + s);
            } else {
                Console.Error.WriteLine(this.getFilename() + ": error: " + s);
            }
        }

        public virtual void reportWarning(string s) {
            if (this.getFilename() == null) {
                Console.Error.WriteLine("warning: " + s);
            } else {
                Console.Error.WriteLine(this.getFilename() + ": warning: " + s);
            }
        }

        public virtual void refresh() {
            if (this.caseSensitive) {
                this.cached_LA2 = this.inputState.input.LA(2);
                this.cached_LA1 = this.inputState.input.LA(1);
            } else {
                this.cached_LA2 = this.toLower(this.inputState.input.LA(2));
                this.cached_LA1 = this.toLower(this.inputState.input.LA(1));
            }
        }

        public virtual void resetState(InputBuffer ib) {
            this.text.Length = 0;
            this.traceDepth = 0;
            this.inputState.resetInput(ib);
            this.refresh();
        }

        public void resetState(Stream s) {
            this.resetState(new ByteBuffer(s));
        }

        public void resetState(TextReader tr) {
            this.resetState(new CharBuffer(tr));
        }

        public virtual void resetText() {
            this.text.Length = 0;
            this.inputState.tokenStartColumn = this.inputState.column;
            this.inputState.tokenStartLine = this.inputState.line;
        }

        public virtual void rewind(int pos) {
            this.inputState.input.rewind(pos);
            this.cached_LA2 = this.inputState.input.LA(2);
            this.cached_LA1 = this.inputState.input.LA(1);
        }

        public virtual void setCaseSensitive(bool t) {
            this.caseSensitive = t;
            if (this.caseSensitive) {
                this.cached_LA2 = this.inputState.input.LA(2);
                this.cached_LA1 = this.inputState.input.LA(1);
            } else {
                this.cached_LA2 = this.toLower(this.inputState.input.LA(2));
                this.cached_LA1 = this.toLower(this.inputState.input.LA(1));
            }
        }

        public virtual void setCommitToPath(bool commit) {
            this.commitToPath = commit;
        }

        public virtual void setFilename(string f) {
            this.inputState.filename = f;
        }

        public virtual void setLine(int line) {
            this.inputState.line = line;
        }

        public virtual void setText(string s) {
            this.resetText();
            this.text.Append(s);
        }

        public virtual void setTokenObjectClass(string cl) {
            this.tokenCreator = new ReflectionBasedTokenCreator(cl);
        }

        public virtual void setTokenCreator(TokenCreator newTokenCreator) {
            this.tokenCreator = newTokenCreator;
        }

        public virtual int testLiteralsTable(int ttype) {
            string text = this.text.ToString();
            if (text != null && !(text == string.Empty)) {
                object obj = this.literals[text];
                if (obj != null) {
                    return (int)obj;
                }
                return ttype;
            }
            return ttype;
        }

        public virtual int testLiteralsTable(string someText, int ttype) {
            if (someText != null && !(someText == string.Empty)) {
                object obj = this.literals[someText];
                if (obj != null) {
                    return (int)obj;
                }
                return ttype;
            }
            return ttype;
        }

        public virtual char toLower(int c) {
            return char.ToLower(Convert.ToChar(c), CultureInfo.InvariantCulture);
        }

        public virtual void traceIndent() {
            for (int i = 0; i < this.traceDepth; i++) {
                Console.Out.Write(" ");
            }
        }

        public virtual void traceIn(string rname) {
            this.traceDepth++;
            this.traceIndent();
            Console.Out.WriteLine("> lexer " + rname + "; c==" + this.LA(1));
        }

        public virtual void traceOut(string rname) {
            this.traceIndent();
            Console.Out.WriteLine("< lexer " + rname + "; c==" + this.LA(1));
            this.traceDepth--;
        }

        public virtual void uponEOF() {
        }
    }
}
