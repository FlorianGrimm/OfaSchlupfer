namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableRebuildStatement : AlterTableStatement {
        private PartitionSpecifier _partition;

        private List<IndexOption> _indexOptions = new List<IndexOption>();

        public PartitionSpecifier Partition {
            get {
                return this._partition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._partition = value;
            }
        }

        public List<IndexOption> IndexOptions {
            get {
                return this._indexOptions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            this.Partition?.Accept(visitor);
            for (int i = 0, count = this.IndexOptions.Count; i < count; i++) {
                this.IndexOptions[i].Accept(visitor);
            }
        }
    }
}
