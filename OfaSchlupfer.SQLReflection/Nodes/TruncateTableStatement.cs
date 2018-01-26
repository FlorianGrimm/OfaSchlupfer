namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TruncateTableStatement : SqlStatement {
        public TruncateTableStatement() : base() { }
        public TruncateTableStatement(ScriptDom.TruncateTableStatement src) : base(src) {
            this.TableName = Copier.Copy<SchemaObjectName>(src.TableName);
            Copier.CopyList(this.PartitionRanges, src.PartitionRanges);
        }

        public SchemaObjectName TableName { get; set; }

        public List<CompressionPartitionRange> PartitionRanges { get; } = new List<CompressionPartitionRange>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.TableName?.Accept(visitor);
            this.PartitionRanges.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
