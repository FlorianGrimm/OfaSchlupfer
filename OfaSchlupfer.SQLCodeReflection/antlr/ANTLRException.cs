#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented

namespace antlr {
    using System;
    using System.Runtime.Serialization;

    [System.Serializable]
    internal class ANTLRException : Exception {
        public ANTLRException() {
        }

        public ANTLRException(string s)
            : base(s) {
        }

        public ANTLRException(string s, Exception inner)
            : base(s, inner) {
        }

        protected ANTLRException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
