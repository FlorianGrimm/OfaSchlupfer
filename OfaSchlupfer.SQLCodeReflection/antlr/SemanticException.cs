#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace antlr {
    using System.Runtime.Serialization;

    [System.Serializable]
    internal class SemanticException : RecognitionException {
        public SemanticException(string s)
            : base(s) {
        }

        public SemanticException(string s, string fileName, int line, int column)
            : base(s, fileName, line, column) {
        }

        protected SemanticException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
