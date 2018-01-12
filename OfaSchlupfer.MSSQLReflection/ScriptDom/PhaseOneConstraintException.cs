using System;
using System.Runtime.Serialization;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal sealed class PhaseOneConstraintException : Exception {
        private ConstraintDefinition _constraint;

        public ConstraintDefinition Constraint {
            get {
                return this._constraint;
            }
        }

        public PhaseOneConstraintException(ConstraintDefinition constraint) {
            this._constraint = constraint;
        }

        private PhaseOneConstraintException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
