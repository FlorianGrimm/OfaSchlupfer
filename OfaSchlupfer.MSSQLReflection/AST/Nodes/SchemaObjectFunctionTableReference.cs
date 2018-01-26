#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class SchemaObjectFunctionTableReference : TableReferenceWithAliasAndColumns {
        public SchemaObjectFunctionTableReference() : base() { }
        public SchemaObjectFunctionTableReference(ScriptDom.SchemaObjectFunctionTableReference src) : base(src) {
            this.SchemaObject = Copier.Copy<SchemaObjectName>(src.SchemaObject);
            Copier.CopyList(this.Parameters, src.Parameters);
        }

        public SchemaObjectName SchemaObject { get; set; }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SchemaObject?.Accept(visitor);
            base.AcceptChildren(visitor);
            this.Parameters.Accept(visitor);
        }
    }
}
