#pragma warning disable CA2214

namespace antlr {
    internal class CharQueue {
        protected internal char[] buffer;

        private int sizeLessOne;

        private int offset;

        protected internal int nbrEntries;

        public CharQueue(int minSize) {
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

        public void append(char tok) {
            if (this.nbrEntries == this.buffer.Length) {
                this.expand();
            }
            this.buffer[this.offset + this.nbrEntries & this.sizeLessOne] = tok;
            this.nbrEntries++;
        }

        public char elementAt(int idx) {
            return this.buffer[this.offset + idx & this.sizeLessOne];
        }

        private void expand() {
            char[] array = new char[this.buffer.Length * 2];
            for (int i = 0; i < this.buffer.Length; i++) {
                array[i] = this.elementAt(i);
            }
            this.buffer = array;
            this.sizeLessOne = this.buffer.Length - 1;
            this.offset = 0;
        }

        public virtual void init(int size) {
            this.buffer = new char[size];
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
