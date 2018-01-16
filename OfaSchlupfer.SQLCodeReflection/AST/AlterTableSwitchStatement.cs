namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableSwitchStatement : AlterTableStatement {
        private ScalarExpression _sourcePartitionNumber;

        private ScalarExpression _targetPartitionNumber;

        private SchemaObjectName _targetTable;

        public ScalarExpression SourcePartitionNumber {
            get {
                return this._sourcePartitionNumber;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sourcePartitionNumber = value;
            }
        }

        public ScalarExpression TargetPartitionNumber {
            get {
                return this._targetPartitionNumber;
            }

            set {
                this.UpdateTokenInfo(value);
                this._targetPartitionNumber = value;
            }
        }

        public SchemaObjectName TargetTable {
            get {
                return this._targetTable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._targetTable = value;
            }
        }

        public List<TableSwitchOption> Options { get; } = new List<TableSwitchOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.SourcePartitionNumber?.Accept(visitor);
            this.TargetPartitionNumber?.Accept(visitor);
            this.TargetTable?.Accept(visitor);
            this.Options.Accept(visitor);
        }
    }
}
