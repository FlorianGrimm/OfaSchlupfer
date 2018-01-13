namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UpdateTextStatement : TextModificationStatement {
        private ScalarExpression _insertOffset;

        private ScalarExpression _deleteLength;

        private ColumnReferenceExpression _sourceColumn;

        private ValueExpression _sourceParameter;

        public ScalarExpression InsertOffset {
            get {
                return this._insertOffset;
            }

            set {
                this.UpdateTokenInfo(value);
                this._insertOffset = value;
            }
        }

        public ScalarExpression DeleteLength {
            get {
                return this._deleteLength;
            }

            set {
                this.UpdateTokenInfo(value);
                this._deleteLength = value;
            }
        }

        public ColumnReferenceExpression SourceColumn {
            get {
                return this._sourceColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sourceColumn = value;
            }
        }

        public ValueExpression SourceParameter {
            get {
                return this._sourceParameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sourceParameter = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.InsertOffset?.Accept(visitor);
            this.DeleteLength?.Accept(visitor);
            this.SourceColumn?.Accept(visitor);
            this.SourceParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
