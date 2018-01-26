namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SchemaObjectNameOrValueExpression : SqlNode {
        public SchemaObjectNameOrValueExpression() : base() { }
        public SchemaObjectNameOrValueExpression(ScriptDom.SchemaObjectNameOrValueExpression src) : base(src) {
            this.SchemaObjectName = Copier.Copy<SchemaObjectName>(src.SchemaObjectName);
            this.ValueExpression = Copier.Copy<ValueExpression>(src.ValueExpression);
        }

        public SchemaObjectName SchemaObjectName { get; set; }

        public ValueExpression ValueExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.ValueExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
