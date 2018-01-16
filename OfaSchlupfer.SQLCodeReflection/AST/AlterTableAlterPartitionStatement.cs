namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterTableAlterPartitionStatement : AlterTableStatement {
        private ScalarExpression _boundaryValue;

        public ScalarExpression BoundaryValue {
            get {
                return this._boundaryValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._boundaryValue = value;
            }
        }

        public bool IsSplit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.BoundaryValue?.Accept(visitor);
        }
    }
}
