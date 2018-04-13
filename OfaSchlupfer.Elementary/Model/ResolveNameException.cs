namespace OfaSchlupfer.Model {
    using System;
    using System.Runtime.Serialization;

    [System.Serializable]
    public class ResolveNameException : ModelException {
        public ResolveNameException() : base("ResolveName") { }

        public ResolveNameException(string message) : base(message) { }

        public ResolveNameException(string message, ModelErrors modelErrors) : base(message, modelErrors) { }

        public ResolveNameException(string message, System.Exception innerException) : base(message, innerException) { }

        protected ResolveNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public new static Exception Factory(ModelErrorInfo modelErrorInfo) => new ResolveNameException(string.Empty, new ModelErrors(modelErrorInfo));
    }

    [System.Serializable]
    public class ResolveNameNotFoundException : ResolveNameException {
        public ResolveNameNotFoundException() : base("not found.") { }

        public ResolveNameNotFoundException(string message) : base(message) { }

        public ResolveNameNotFoundException(string message, ModelErrors modelErrors) : base(message, modelErrors) { }

        public ResolveNameNotFoundException(string message, System.Exception innerException) : base(message, innerException) { }

        protected ResolveNameNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public new static Exception Factory(ModelErrorInfo modelErrorInfo) => new ResolveNameNotFoundException(string.Empty, new ModelErrors(modelErrorInfo));
    }

    [System.Serializable]
    public class ResolveNameNotUniqueException : ResolveNameException {
        public ResolveNameNotUniqueException() : base("is not unique.") { }

        public ResolveNameNotUniqueException(string message) : base(message) { }

        public ResolveNameNotUniqueException(string message, ModelErrors modelErrors) : base(message, modelErrors) { }

        public ResolveNameNotUniqueException(string message, System.Exception innerException) : base(message, innerException) { }

        protected ResolveNameNotUniqueException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public new static Exception Factory(ModelErrorInfo modelErrorInfo) => new ResolveNameNotUniqueException(string.Empty, new ModelErrors(modelErrorInfo));
    }
}