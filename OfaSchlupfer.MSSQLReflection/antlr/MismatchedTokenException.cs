#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented

namespace antlr {
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Text;
    using antlr.collections.impl;

    [System.Serializable]
    internal class MismatchedTokenException : RecognitionException {
        internal enum TokenTypeEnum {
            TokenType = 1,
            NotTokenType,
            RangeType,
            NotRangeType,
            SetType,
            NotSetType
        }

        internal string[] tokenNames;

        public IToken token;

        internal string tokenText;

        public TokenTypeEnum mismatchType;

        public int expecting;

        public int upper;

        public BitSet bset;

        public override string Message {
            get {
                StringBuilder stringBuilder = new StringBuilder();
                switch (this.mismatchType) {
                    case TokenTypeEnum.TokenType:
                        stringBuilder.Append("expecting " + this.tokenName(this.expecting) + ", found '" + this.tokenText + "'");
                        break;
                    case TokenTypeEnum.NotTokenType:
                        stringBuilder.Append("expecting anything but " + this.tokenName(this.expecting) + "; got it anyway");
                        break;
                    case TokenTypeEnum.RangeType:
                        stringBuilder.Append("expecting token in range: " + this.tokenName(this.expecting) + ".." + this.tokenName(this.upper) + ", found '" + this.tokenText + "'");
                        break;
                    case TokenTypeEnum.NotRangeType:
                        stringBuilder.Append("expecting token NOT in range: " + this.tokenName(this.expecting) + ".." + this.tokenName(this.upper) + ", found '" + this.tokenText + "'");
                        break;
                    case TokenTypeEnum.SetType:
                    case TokenTypeEnum.NotSetType: {
                            stringBuilder.Append("expecting " + ((this.mismatchType == TokenTypeEnum.NotSetType) ? "NOT " : string.Empty) + "one of (");
                            int[] array = this.bset.toArray();
                            for (int i = 0; i < array.Length; i++) {
                                stringBuilder.Append(" ");
                                stringBuilder.Append(this.tokenName(array[i]));
                            }
                            stringBuilder.Append("), found '" + this.tokenText + "'");
                            break;
                        }
                    default:
                        stringBuilder.Append(base.Message);
                        break;
                }
                return stringBuilder.ToString();
            }
        }

        public MismatchedTokenException()
            : base("Mismatched Token: expecting any AST node", "<AST>", -1, -1) {
        }

        public MismatchedTokenException(string[] tokenNames_, IToken token_, int lower, int upper_, bool matchNot, string fileName_)
            : base("Mismatched Token", fileName_, token_.getLine(), token_.getColumn()) {
            this.tokenNames = tokenNames_;
            this.token = token_;
            this.tokenText = token_.getText();
            this.mismatchType = (TokenTypeEnum)(matchNot ? 4 : 3);
            this.expecting = lower;
            this.upper = upper_;
        }

        public MismatchedTokenException(string[] tokenNames_, IToken token_, int expecting_, bool matchNot, string fileName_)
            : base("Mismatched Token", fileName_, token_.getLine(), token_.getColumn()) {
            this.tokenNames = tokenNames_;
            this.token = token_;
            this.tokenText = token_.getText();
            this.mismatchType = (TokenTypeEnum)((!matchNot) ? 1 : 2);
            this.expecting = expecting_;
        }

        public MismatchedTokenException(string[] tokenNames_, IToken token_, BitSet set_, bool matchNot, string fileName_)
            : base("Mismatched Token", fileName_, token_.getLine(), token_.getColumn()) {
            this.tokenNames = tokenNames_;
            this.token = token_;
            this.tokenText = token_.getText();
            this.mismatchType = (TokenTypeEnum)(matchNot ? 6 : 5);
            this.bset = set_;
        }

        protected MismatchedTokenException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        private string tokenName(int tokenType) {
            if (tokenType == 0) {
                return "<Set of tokens>";
            }
            if (tokenType >= 0 && tokenType < this.tokenNames.Length) {
                return this.tokenNames[tokenType];
            }
            return "<" + tokenType.ToString(CultureInfo.InvariantCulture) + ">";
        }
    }
}
