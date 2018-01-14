#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace antlr {
    internal class ParserSharedInputState {
        protected internal TokenBuffer input;

        public int guessing;

        protected internal string filename;

        public virtual void reset() {
            this.guessing = 0;
            this.filename = null;
            this.input.reset();
        }
    }
}
