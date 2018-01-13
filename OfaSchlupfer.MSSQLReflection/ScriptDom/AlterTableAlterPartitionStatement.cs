namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterTableAlterPartitionStatement : AlterTableStatement {
        private ScalarExpression _boundaryValue;

        private bool _isSplit;

        public ScalarExpression BoundaryValue {
            get {
                return this._boundaryValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._boundaryValue = value;
            }
        }

        public bool IsSplit {
            get {
                return this._isSplit;
            }

            set {
                this._isSplit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            this.BoundaryValue?.Accept(visitor);
        }
    }
}
