namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableRebuildStatement : AlterTableStatement {
        private PartitionSpecifier _partition;

        public PartitionSpecifier Partition {
            get {
                return this._partition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._partition = value;
            }
        }

        public List<IndexOption> IndexOptions { get; } = new List<IndexOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.Partition?.Accept(visitor);
            this.IndexOptions.Accept(visitor);
        }
    }
}
