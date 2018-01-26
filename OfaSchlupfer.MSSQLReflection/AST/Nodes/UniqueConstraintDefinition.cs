#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class UniqueConstraintDefinition : ConstraintDefinition {
        public UniqueConstraintDefinition() : base() { }
        public UniqueConstraintDefinition(ScriptDom.UniqueConstraintDefinition src) : base(src) {
            this.Clustered = src.Clustered;
            this.IsPrimaryKey = src.IsPrimaryKey;
            Copier.CopyList(this.Columns, src.Columns);
            this.OnFileGroupOrPartitionScheme = Copier.Copy<FileGroupOrPartitionScheme>(src.OnFileGroupOrPartitionScheme);
            this.IndexType = Copier.Copy<IndexType>(src.IndexType);
            this.FileStreamOn = Copier.Copy<IdentifierOrValueExpression>(src.FileStreamOn);
        }

        public bool? Clustered { get; set; }

        public bool IsPrimaryKey { get; set; }

        public List<ColumnWithSortOrder> Columns { get; } = new List<ColumnWithSortOrder>();

        /*
        public List<IndexOption> IndexOptions { get; } = new List<IndexOption>();
         */

        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme { get; set; }

        public IndexType IndexType { get; set; }

        public IdentifierOrValueExpression FileStreamOn { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Columns.Accept(visitor);
            // this.IndexOptions.Accept(visitor);
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            this.FileStreamOn?.Accept(visitor);
        }
    }
}
