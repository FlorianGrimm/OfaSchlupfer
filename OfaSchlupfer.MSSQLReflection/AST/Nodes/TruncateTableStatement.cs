#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
