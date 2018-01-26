#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class CreateTableStatement : SqlStatement {
        public CreateTableStatement() : base() { }
        public CreateTableStatement(ScriptDom.CreateTableStatement src) : base(src) {
            this.SchemaObjectName = Copier.Copy<SchemaObjectName>(src.SchemaObjectName);
            this.AsEdge = src.AsEdge;
            this.AsFileTable = src.AsFileTable;
            this.AsNode = src.AsNode;
            this.Definition = Copier.Copy<TableDefinition>(src.Definition);
            this.TextImageOn = Copier.Copy<IdentifierOrValueExpression>(src.TextImageOn);
            this.FileStreamOn = Copier.Copy<IdentifierOrValueExpression>(src.FileStreamOn);
        }
        public SchemaObjectName SchemaObjectName { get; set; }

        public bool AsEdge { get; set; }

        public bool AsFileTable { get; set; }

        public bool AsNode { get; set; }

        public TableDefinition Definition { get; set; }

        /*
        // public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme { get; set; }
        // public FederationScheme FederationScheme { get; set; }
        // public List<TableOption> Options { get; } = new List<TableOption>();
        */

        public IdentifierOrValueExpression TextImageOn { get; set; }

        public IdentifierOrValueExpression FileStreamOn { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.Definition?.Accept(visitor);
            // this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            // this.FederationScheme?.Accept(visitor);
            this.TextImageOn?.Accept(visitor);
            // this.Options.Accept(visitor);
            this.FileStreamOn?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
