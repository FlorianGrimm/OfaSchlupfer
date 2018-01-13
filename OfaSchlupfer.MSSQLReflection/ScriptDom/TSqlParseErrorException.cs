namespace OfaSchlupfer.ScriptDom {
    using System;
    using System.Runtime.Serialization;

    [System.Serializable]
    internal sealed class TSqlParseErrorException : Exception {
        private ParseError _parseError;

        private bool _doNotLog;

        public bool DoNotLog {
            get {
                return this._doNotLog;
            }
        }

        public ParseError ParseError {
            get {
                return this._parseError;
            }
        }

        public TSqlParseErrorException(ParseError error, bool doNotLog) {
            this._parseError = error;
            this._doNotLog = doNotLog;
        }

        public TSqlParseErrorException(ParseError error)
            : this(error, false) {
        }

        private TSqlParseErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
