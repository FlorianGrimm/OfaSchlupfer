namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class TSqlStatementSnippet : SqlStatement {
        public TSqlStatementSnippet() : base() { }
        public TSqlStatementSnippet(ScriptDom.TSqlStatementSnippet src) : base(src) {
            this.Script = src.Script;
        }

        public string Script { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
