namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class LabelStatement : SqlStatement {
        public LabelStatement() : base() { }
        public LabelStatement(ScriptDom.LabelStatement src) : base(src) {
            this.Value = src.Value;
        }

        public string Value { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
