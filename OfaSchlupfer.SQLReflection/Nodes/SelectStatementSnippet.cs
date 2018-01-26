namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SelectStatementSnippet : SelectStatement {
        public SelectStatementSnippet() : base() { }
        public SelectStatementSnippet(ScriptDom.SelectStatementSnippet src) : base(src) {
            this.Script = src.Script;
        }

        public string Script { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
