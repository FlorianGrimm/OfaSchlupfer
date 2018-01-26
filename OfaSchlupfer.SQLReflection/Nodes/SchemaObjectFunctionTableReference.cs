namespace OfaSchlupfer.SQLReflection {
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
