using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ParseError {
        private readonly int _number;

        private readonly int _offset;

        private readonly int _line;

        private readonly int _column;

        private readonly string _message;

        public int Number {
            get {
                return this._number;
            }
        }

        public int Offset {
            get {
                return this._offset;
            }
        }

        public int Line {
            get {
                return this._line;
            }
        }

        public int Column {
            get {
                return this._column;
            }
        }

        public string Message {
            get {
                return this._message;
            }
        }

        public ParseError(int number, int offset, int line, int column, string message) {
            this._number = number;
            this._offset = offset;
            this._message = message;
            this._line = line;
            this._column = column;
        }
    }
}
