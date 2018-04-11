namespace OfaSchlupfer.SPO {
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ClientRequestException : Exception {
        public ClientRequestException(string message)
            : base(message) {
        }

        public ClientRequestException(string message, Exception innerException)
            : base(message, innerException) {
        }

        protected ClientRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
