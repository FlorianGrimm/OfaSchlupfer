#pragma warning disable CA2214

namespace antlr {
    internal class CommonToken : Token {
        internal class CommonTokenCreator : TokenCreator {
            public override string TokenTypeName {
                get {
                    return typeof(CommonToken).FullName;
                }
            }

            public override IToken Create() {
                return new CommonToken();
            }
        }

        public static readonly CommonTokenCreator Creator = new CommonTokenCreator();

        protected internal int line;

        protected internal string text;

        protected internal int col;

        public CommonToken() {
        }

        public CommonToken(int t, string txt) {
            base.type_ = t;
            this.setText(txt);
        }

        public CommonToken(string s) {
            this.text = s;
        }

        public override int getLine() {
            return this.line;
        }

        public override string getText() {
            return this.text;
        }

        public override void setLine(int l) {
            this.line = l;
        }

        public override void setText(string s) {
            this.text = s;
        }

        public override string ToString() {
            return "[\"" + this.getText() + "\",<" + base.type_ + ">,line=" + this.line + ",col=" + this.col + "]";
        }

        public override int getColumn() {
            return this.col;
        }

        public override void setColumn(int c) {
            this.col = c;
        }
    }
}
