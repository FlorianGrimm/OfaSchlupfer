namespace OfaSchlupfer {
    using System.Runtime.Serialization;

    [System.Serializable]
    public class OfaSchlupferException : System.Exception {
        public OfaSchlupferException() : base("invalid operation") { }

        public OfaSchlupferException(string message) : base(message) { }

        public OfaSchlupferException(string message, System.Exception innerException) : base(message, innerException) { }

        protected OfaSchlupferException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}