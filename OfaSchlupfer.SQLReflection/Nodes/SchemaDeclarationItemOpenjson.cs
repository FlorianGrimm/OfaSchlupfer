namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SchemaDeclarationItemOpenjson : SchemaDeclarationItem {
        public SchemaDeclarationItemOpenjson() : base() { }
        public SchemaDeclarationItemOpenjson(ScriptDom.SchemaDeclarationItemOpenjson src) : base(src) {
            this.AsJson = src.AsJson;
        }
        public bool AsJson { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
