using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class TextModificationStatement : TSqlStatement {
        private bool _bulk;

        private ColumnReferenceExpression _column;

        private ValueExpression _textId;

        private Literal _timestamp;

        private bool _withLog;

        public bool Bulk {
            get {
                return this._bulk;
            }

            set {
                this._bulk = value;
            }
        }

        public ColumnReferenceExpression Column {
            get {
                return this._column;
            }

            set {
                this.UpdateTokenInfo(value);
                this._column = value;
            }
        }

        public ValueExpression TextId {
            get {
                return this._textId;
            }

            set {
                this.UpdateTokenInfo(value);
                this._textId = value;
            }
        }

        public Literal Timestamp {
            get {
                return this._timestamp;
            }

            set {
                this.UpdateTokenInfo(value);
                this._timestamp = value;
            }
        }

        public bool WithLog {
            get {
                return this._withLog;
            }

            set {
                this._withLog = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            this.TextId?.Accept(visitor);
            this.Timestamp?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
