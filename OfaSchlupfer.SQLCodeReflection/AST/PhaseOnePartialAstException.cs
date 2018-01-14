using System;
using System.Runtime.Serialization;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    internal sealed class PhaseOnePartialAstException : Exception {
        private TSqlStatement _statement;

        public TSqlStatement Statement {
            get {
                return this._statement;
            }
        }

        public PhaseOnePartialAstException(TSqlStatement statement) {
            this._statement = statement;
        }

        private PhaseOnePartialAstException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
