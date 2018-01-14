#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace antlr {
    using System.Runtime.Serialization;

    [System.Serializable]
    internal class NoViableAltException : RecognitionException {
        public IToken token;

        public override string Message {
            get {
                if (this.token != null) {
                    return "unexpected token: " + this.token.ToString();
                }
                return "unexpected token: (null)";
            }
        }

        public NoViableAltException(IToken t, string fileName_)
            : base("NoViableAlt", fileName_, t.getLine(), t.getColumn()) {
            this.token = t;
        }

        protected NoViableAltException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
