namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SetTransactionIsolationLevelStatement : SqlStatement {
        public SetTransactionIsolationLevelStatement() : base() { }

        public SetTransactionIsolationLevelStatement(ScriptDom.SetTransactionIsolationLevelStatement src) : base(src) {
            this.Level = src.Level;
        }

        public Microsoft.SqlServer.TransactSql.ScriptDom.IsolationLevel Level { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
