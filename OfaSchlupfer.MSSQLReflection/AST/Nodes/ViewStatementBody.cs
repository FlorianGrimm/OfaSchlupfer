#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public abstract class ViewStatementBody : SqlStatement {
        public ViewStatementBody() : base() { }
        public ViewStatementBody(ScriptDom.ViewStatementBody src) : base(src) {
            this.SchemaObjectName = Copier.Copy<SchemaObjectName>(src.SchemaObjectName);
            Copier.CopyList(this.Columns, src.Columns);
            this.SelectStatement = Copier.Copy<SelectStatement>(src.SelectStatement);
            this.WithCheckOption = src.WithCheckOption;
        }
        public SchemaObjectName SchemaObjectName { get; set; }

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public SelectStatement SelectStatement { get; set; }

        public bool WithCheckOption { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.Columns.Accept(visitor);
            this.SelectStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
