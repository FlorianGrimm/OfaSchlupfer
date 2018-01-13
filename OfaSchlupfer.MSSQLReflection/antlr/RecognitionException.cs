#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace antlr {
    using System.Runtime.Serialization;

    [System.Serializable]
    internal class RecognitionException : ANTLRException {
        public string fileName;

        public int line;

        public int column;

        public RecognitionException()
            : base("parsing error") {
            this.fileName = null;
            this.line = -1;
            this.column = -1;
        }

        public RecognitionException(string s)
            : base(s) {
            this.fileName = null;
            this.line = -1;
            this.column = -1;
        }

        public RecognitionException(string s, string fileName_, int line_, int column_)
            : base(s) {
            this.fileName = fileName_;
            this.line = line_;
            this.column = column_;
        }

        protected RecognitionException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public virtual string getFilename() {
            return this.fileName;
        }

        public virtual int getLine() {
            return this.line;
        }

        public virtual int getColumn() {
            return this.column;
        }

        public override string ToString() {
            return FileLineFormatter.getFormatter().getFormatString(this.fileName, this.line, this.column) + this.Message;
        }
    }
}
