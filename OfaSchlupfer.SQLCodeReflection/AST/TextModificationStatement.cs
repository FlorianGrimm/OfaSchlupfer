namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class TextModificationStatement : TSqlStatement {
        private ColumnReferenceExpression _column;

        private ValueExpression _textId;

        private Literal _timestamp;

        public bool Bulk { get; set; }

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

        public bool WithLog { get; set; }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            this.TextId?.Accept(visitor);
            this.Timestamp?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
