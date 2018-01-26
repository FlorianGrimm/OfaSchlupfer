namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class SchemaDeclarationItem : SqlNode {
        public SchemaDeclarationItem() : base() { }
        public SchemaDeclarationItem(ScriptDom.SchemaDeclarationItem src) : base(src) {
            this.ColumnDefinition = Copier.Copy<ColumnDefinitionBase>(src.ColumnDefinition);
        }
        public ColumnDefinitionBase ColumnDefinition { get; set; }

        public ValueExpression Mapping { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ColumnDefinition?.Accept(visitor);
            this.Mapping?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
