#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SchemaObjectResultSetDefinition : ResultSetDefinition {
        public SchemaObjectResultSetDefinition() : base() { }
        public SchemaObjectResultSetDefinition(ScriptDom.SchemaObjectResultSetDefinition src) : base(src) {
            this.Name = Copier.Copy<SchemaObjectName>(src.Name);
        }
        public SchemaObjectName Name { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
        }
    }
}
