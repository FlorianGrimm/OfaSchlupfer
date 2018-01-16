namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TruncateTableStatement : TSqlStatement {
        private SchemaObjectName _tableName;

        public SchemaObjectName TableName {
            get {
                return this._tableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableName = value;
            }
        }

        public List<CompressionPartitionRange> PartitionRanges { get; } = new List<CompressionPartitionRange>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.TableName?.Accept(visitor);
            this.PartitionRanges.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
