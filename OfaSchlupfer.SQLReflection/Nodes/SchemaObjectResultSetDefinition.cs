namespace OfaSchlupfer.SQLReflection {
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
