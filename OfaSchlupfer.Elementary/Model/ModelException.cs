namespace OfaSchlupfer.Model {
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ModelException : OfaSchlupferException {
        public ModelException() : base() { }

        public ModelException(string message) : base(message) {
        }

        public ModelException(string message, Exception innerException) : base(message, innerException) {
        }

        public ModelException(string message, ModelErrors modelErrors) : base(message) {
        }
        

        protected ModelException(SerializationInfo info, StreamingContext context) : base(info, context) {
            try {
                this.ModelErrors = (ModelErrors)(info.GetValue("ModelErrors", typeof(ModelErrors)));
            } catch { }
        }

        public ModelErrors ModelErrors { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);
            info.AddValue("ModelErrors", this.ModelErrors, typeof(ModelErrors));
        }
    }
}