namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;
    using OfaSchlupfer.MSSQLReflection.SqlCode;

    [System.Serializable]
    public abstract class TSqlFragment {
        public const int Uninitialized = -1;

        private int _firstTokenIndex = -1;

        private int _lastTokenIndex = -1;

        private IList<TSqlParserToken> _scriptTokenStream;

        public SqlCodeScope SqlCodeScope;
        public ISqlCodeType SqlCodeType;
        public ISqlCodeResult SqlCodeResult;

        public int StartOffset {
            get {
                if (this._firstTokenIndex != -1 && this._scriptTokenStream != null) {
                    return this._scriptTokenStream[this._firstTokenIndex].Offset;
                }
                return -1;
            }
        }

        public int FragmentLength {
            get {
                if (this._firstTokenIndex != -1 && this._lastTokenIndex != -1 && this._scriptTokenStream != null) {
                    TSqlParserToken tSqlParserToken = this._scriptTokenStream[this._lastTokenIndex];
                    int num = (tSqlParserToken.Text != null) ? tSqlParserToken.Text.Length : 0;
                    return tSqlParserToken.Offset - this._scriptTokenStream[this._firstTokenIndex].Offset + num;
                }
                return -1;
            }
        }

        public int StartLine {
            get {
                if (this._firstTokenIndex != -1 && this._scriptTokenStream != null) {
                    return this._scriptTokenStream[this._firstTokenIndex].Line;
                }
                return -1;
            }
        }

        public int StartColumn {
            get {
                if (this._firstTokenIndex != -1 && this._scriptTokenStream != null) {
                    return this._scriptTokenStream[this._firstTokenIndex].Column;
                }
                return -1;
            }
        }

        public int FirstTokenIndex {
            get {
                return this._firstTokenIndex;
            }

            set {
                this._firstTokenIndex = value;
            }
        }

        public int LastTokenIndex {
            get {
                return this._lastTokenIndex;
            }

            set {
                this._lastTokenIndex = value;
            }
        }

        public IList<TSqlParserToken> ScriptTokenStream {
            get {
                return this._scriptTokenStream;
            }

            set {
                this._scriptTokenStream = value;
            }
        }

        internal void UpdateTokenInfo(TSqlFragment fragment) {
            if (fragment != null) {
                this.UpdateTokenInfo(fragment.FirstTokenIndex, fragment.LastTokenIndex);
                if (fragment.ScriptTokenStream != null) {
                    this.ScriptTokenStream = fragment.ScriptTokenStream;
                }
            }
        }

        internal void UpdateTokenInfo(int firstIndex, int lastIndex) {
            if (firstIndex >= 0 && lastIndex >= 0) {
                if (firstIndex > lastIndex) {
                    int num = firstIndex;
                    firstIndex = lastIndex;
                    lastIndex = num;
                }
                if (firstIndex < this._firstTokenIndex || this._firstTokenIndex == -1) {
                    this._firstTokenIndex = firstIndex;
                }
                if (lastIndex <= this._lastTokenIndex && this._lastTokenIndex != -1) {
                    return;
                }
                this._lastTokenIndex = lastIndex;
            }
        }

        public virtual void Accept(TSqlFragmentVisitor visitor) {
        }

        public virtual void AcceptChildren(TSqlFragmentVisitor visitor) {
        }
    }
}
