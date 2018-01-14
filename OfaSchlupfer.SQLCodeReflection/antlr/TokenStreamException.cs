#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1600 // Elements must be documented

namespace antlr {
    using System.Runtime.Serialization;

    [System.Serializable]
    internal class TokenStreamException : ANTLRException {
        public TokenStreamException() {
        }

        public TokenStreamException(string s)
            : base(s) {
        }

        protected TokenStreamException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
