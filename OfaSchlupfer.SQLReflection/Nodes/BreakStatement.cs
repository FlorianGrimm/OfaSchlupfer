namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class BreakStatement : SqlStatement {
        public BreakStatement() : base() { }
        public BreakStatement(ScriptDom.BreakStatement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
