namespace OfaSchlupfer.ModelOData.SPO {
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class IdcrlException : Exception {
        public int ErrorCode {
            get {
                return base.HResult;
            }
        }

        public IdcrlException() {
        }

        public IdcrlException(string message)
            : base(message) {
        }

        public IdcrlException(string message, Exception innerException)
            : base(message, innerException) {
        }

        public IdcrlException(string message, int errorcode)
            : base(message) {
            base.HResult = errorcode;
        }

        private IdcrlException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
