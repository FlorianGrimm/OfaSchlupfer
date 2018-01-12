using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ReadTextStatement : TSqlStatement {
        private ColumnReferenceExpression _column;

        private ValueExpression _textPointer;

        private ValueExpression _offset;

        private ValueExpression _size;

        private bool _holdLock;

        public ColumnReferenceExpression Column {
            get {
                return this._column;
            }

            set {
                this.UpdateTokenInfo(value);
                this._column = value;
            }
        }

        public ValueExpression TextPointer {
            get {
                return this._textPointer;
            }

            set {
                this.UpdateTokenInfo(value);
                this._textPointer = value;
            }
        }

        public ValueExpression Offset {
            get {
                return this._offset;
            }

            set {
                this.UpdateTokenInfo(value);
                this._offset = value;
            }
        }

        public ValueExpression Size {
            get {
                return this._size;
            }

            set {
                this.UpdateTokenInfo(value);
                this._size = value;
            }
        }

        public bool HoldLock {
            get {
                return this._holdLock;
            }

            set {
                this._holdLock = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            this.TextPointer?.Accept(visitor);
            this.Offset?.Accept(visitor);
            this.Size?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
