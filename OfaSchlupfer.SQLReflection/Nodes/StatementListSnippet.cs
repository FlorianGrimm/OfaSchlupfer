namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class StatementListSnippet : StatementList {
        public StatementListSnippet() : base() { }
        public StatementListSnippet(ScriptDom.StatementListSnippet src) : base(src) {
            this.Script = src.Script;
        }

        public string Script { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
