#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented

namespace antlr {
    using System.Collections;
    using System.Text;

    internal abstract class InputBuffer {
        protected internal int nMarkers;

        protected internal int markerOffset;

        protected internal int numToConsume;

        protected ArrayList queue;

        public InputBuffer() {
            this.queue = new ArrayList();
        }

        public virtual void commit() {
            this.nMarkers--;
        }

        public virtual char consume() {
            this.numToConsume++;
            return this.LA(1);
        }

        public abstract void fill(int amount);

        public virtual string getLAChars() {
            StringBuilder stringBuilder = new StringBuilder();
            char[] array = new char[this.queue.Count - this.markerOffset];
            this.queue.CopyTo(array, this.markerOffset);
            stringBuilder.Append(array);
            return stringBuilder.ToString();
        }

        public virtual string getMarkedChars() {
            StringBuilder stringBuilder = new StringBuilder();
            char[] array = new char[this.queue.Count - this.markerOffset];
            this.queue.CopyTo(array, this.markerOffset);
            stringBuilder.Append(array);
            return stringBuilder.ToString();
        }

        public virtual bool isMarked() {
            return this.nMarkers != 0;
        }

        public virtual char LA(int i) {
            this.fill(i);
            return (char)this.queue[this.markerOffset + i - 1];
        }

        public virtual int mark() {
            this.syncConsume();
            this.nMarkers++;
            return this.markerOffset;
        }

        public virtual void rewind(int mark) {
            this.syncConsume();
            this.markerOffset = mark;
            this.nMarkers--;
        }

        public virtual void reset() {
            this.nMarkers = 0;
            this.markerOffset = 0;
            this.numToConsume = 0;
            this.queue.Clear();
        }

        protected internal virtual void syncConsume() {
            if (this.numToConsume > 0) {
                if (this.nMarkers > 0) {
                    this.markerOffset += this.numToConsume;
                } else {
                    this.queue.RemoveRange(0, this.numToConsume);
                }
                this.numToConsume = 0;
            }
        }
    }
}
