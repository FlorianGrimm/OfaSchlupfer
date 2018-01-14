#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1600 // Elements must be documented

namespace antlr {
    using System.Runtime.Serialization;

    [System.Serializable]
    internal class TokenStreamRecognitionException : TokenStreamException {
        public RecognitionException recog;

        public TokenStreamRecognitionException(RecognitionException re)
            : base(re.Message) {
            this.recog = re;
        }

        protected TokenStreamRecognitionException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public override string ToString() {
            return this.recog.ToString();
        }
    }
}
