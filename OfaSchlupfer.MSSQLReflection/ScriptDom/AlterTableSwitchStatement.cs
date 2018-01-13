using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterTableSwitchStatement : AlterTableStatement {
        private ScalarExpression _sourcePartitionNumber;

        private ScalarExpression _targetPartitionNumber;

        private SchemaObjectName _targetTable;

        private List<TableSwitchOption> _options = new List<TableSwitchOption>();

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

        public List<TableSwitchOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            this.SourcePartitionNumber?.Accept(visitor);
            this.TargetPartitionNumber?.Accept(visitor);
            this.TargetTable?.Accept(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }
}
