using System;
using System.Runtime.Serialization;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal sealed class PhaseOneBatchException : Exception {
        public PhaseOneBatchException() {
        }

        private PhaseOneBatchException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
