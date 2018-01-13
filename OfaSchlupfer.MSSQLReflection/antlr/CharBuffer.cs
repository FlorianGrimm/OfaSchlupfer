#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented
#pragma warning disable SA1310 // Field names must not contain underscore

namespace antlr {
    using System;
    using System.IO;

    internal class CharBuffer : InputBuffer {
        private const int BUF_SIZE = 16;

        [NonSerialized]
        internal TextReader input;

        private char[] buf = new char[16];

        public CharBuffer(TextReader input_) {
            this.input = input_;
        }

        public override void fill(int amount) {
            this.syncConsume();
            int num = amount + this.markerOffset - this.queue.Count;
            int num2;
            do {
                if (num <= 0) {
                    return;
                }
                num2 = this.input.Read(this.buf, 0, 16);
                for (int i = 0; i < num2; i++) {
                    this.queue.Add(this.buf[i]);
                }
                num -= num2;
            }
            while (num2 >= 16);
            while (num-- > 0) {
                this.queue.Add(CharScanner.EOF_CHAR);
            }
        }
    }
}
