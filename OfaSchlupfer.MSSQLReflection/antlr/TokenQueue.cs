#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace antlr {
    internal class TokenQueue {
        private IToken[] buffer;

        private int sizeLessOne;

        private int offset;

        protected internal int nbrEntries;

        public TokenQueue(int minSize) {
            if (minSize < 0) {
                this.init(16);
            } else if (minSize >= 1073741823) {
                this.init(2147483647);
            } else {
                int num;
                for (num = 2; num < minSize; num *= 2) {
                }
                this.init(num);
            }
        }

        public void append(IToken tok) {
            if (this.nbrEntries == this.buffer.Length) {
                this.expand();
            }
            this.buffer[this.offset + this.nbrEntries & this.sizeLessOne] = tok;
            this.nbrEntries++;
        }

        public IToken elementAt(int idx) {
            return this.buffer[this.offset + idx & this.sizeLessOne];
        }

        private void expand() {
            IToken[] array = new IToken[this.buffer.Length * 2];
            for (int i = 0; i < this.buffer.Length; i++) {
                array[i] = this.elementAt(i);
            }
            this.buffer = array;
            this.sizeLessOne = this.buffer.Length - 1;
            this.offset = 0;
        }

        private void init(int size) {
            this.buffer = new IToken[size];
            this.sizeLessOne = size - 1;
            this.offset = 0;
            this.nbrEntries = 0;
        }

        public void reset() {
            this.offset = 0;
            this.nbrEntries = 0;
        }

        public void removeFirst() {
            this.offset = (this.offset + 1 & this.sizeLessOne);
            this.nbrEntries--;
        }
    }
}
