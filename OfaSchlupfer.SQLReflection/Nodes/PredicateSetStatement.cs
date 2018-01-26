namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class PredicateSetStatement : SetOnOffStatement {
        public PredicateSetStatement() : base() { }
        public PredicateSetStatement(ScriptDom.PredicateSetStatement src) : base(src) {
            this.Options = src.Options;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.SetOptions Options { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
