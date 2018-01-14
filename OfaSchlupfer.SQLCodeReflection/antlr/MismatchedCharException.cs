#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented

namespace antlr {
    using System.Runtime.Serialization;
    using System.Text;
    using antlr.collections.impl;

    [System.Serializable]
    internal class MismatchedCharException : RecognitionException {
        internal enum CharTypeEnum {
            CharType = 1,
            NotCharType,
            RangeType,
            NotRangeType,
            SetType,
            NotSetType
        }

        public CharTypeEnum mismatchType;

        public int foundChar;

        public int expecting;

        public int upper;

        public BitSet bset;

        public CharScanner scanner;

        public override string Message {
            get {
                StringBuilder stringBuilder = new StringBuilder();
                switch (this.mismatchType) {
                    case CharTypeEnum.CharType:
                        stringBuilder.Append("expecting ");
                        MismatchedCharException.appendCharName(stringBuilder, this.expecting);
                        stringBuilder.Append(", found ");
                        MismatchedCharException.appendCharName(stringBuilder, this.foundChar);
                        break;
                    case CharTypeEnum.NotCharType:
                        stringBuilder.Append("expecting anything but '");
                        MismatchedCharException.appendCharName(stringBuilder, this.expecting);
                        stringBuilder.Append("'; got it anyway");
                        break;
                    case CharTypeEnum.RangeType:
                    case CharTypeEnum.NotRangeType:
                        stringBuilder.Append("expecting token ");
                        if (this.mismatchType == CharTypeEnum.NotRangeType) {
                            stringBuilder.Append("NOT ");
                        }
                        stringBuilder.Append("in range: ");
                        MismatchedCharException.appendCharName(stringBuilder, this.expecting);
                        stringBuilder.Append("..");
                        MismatchedCharException.appendCharName(stringBuilder, this.upper);
                        stringBuilder.Append(", found ");
                        MismatchedCharException.appendCharName(stringBuilder, this.foundChar);
                        break;
                    case CharTypeEnum.SetType:
                    case CharTypeEnum.NotSetType: {
                            stringBuilder.Append("expecting " + ((this.mismatchType == CharTypeEnum.NotSetType) ? "NOT " : string.Empty) + "one of (");
                            int[] array = this.bset.toArray();
                            for (int i = 0; i < array.Length; i++) {
                                MismatchedCharException.appendCharName(stringBuilder, array[i]);
                            }
                            stringBuilder.Append("), found ");
                            MismatchedCharException.appendCharName(stringBuilder, this.foundChar);
                            break;
                        }
                    default:
                        stringBuilder.Append(base.Message);
                        break;
                }
                return stringBuilder.ToString();
            }
        }

        public MismatchedCharException()
            : base("Mismatched char") {
        }

        public MismatchedCharException(char c, char lower, char upper_, bool matchNot, CharScanner scanner_)
            : base("Mismatched char", scanner_.getFilename(), scanner_.getLine(), scanner_.getColumn()) {
            this.mismatchType = (CharTypeEnum)(matchNot ? 4 : 3);
            this.foundChar = c;
            this.expecting = lower;
            this.upper = upper_;
            this.scanner = scanner_;
        }

        public MismatchedCharException(char c, char expecting_, bool matchNot, CharScanner scanner_)
            : base("Mismatched char", scanner_.getFilename(), scanner_.getLine(), scanner_.getColumn()) {
            this.mismatchType = (CharTypeEnum)((!matchNot) ? 1 : 2);
            this.foundChar = c;
            this.expecting = expecting_;
            this.scanner = scanner_;
        }

        public MismatchedCharException(char c, BitSet set_, bool matchNot, CharScanner scanner_)
            : base("Mismatched char", scanner_.getFilename(), scanner_.getLine(), scanner_.getColumn()) {
            this.mismatchType = (CharTypeEnum)(matchNot ? 6 : 5);
            this.foundChar = c;
            this.bset = set_;
            this.scanner = scanner_;
        }

        protected MismatchedCharException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        private static void appendCharName(StringBuilder sb, int c) {
            switch (c) {
                case 65535:
                    sb.Append("'<EOF>'");
                    break;
                case 10:
                    sb.Append("'\\n'");
                    break;
                case 13:
                    sb.Append("'\\r'");
                    break;
                case 9:
                    sb.Append("'\\t'");
                    break;
                default:
                    sb.Append('\'');
                    sb.Append((char)(ushort)c);
                    sb.Append('\'');
                    break;
            }
        }
    }
}
