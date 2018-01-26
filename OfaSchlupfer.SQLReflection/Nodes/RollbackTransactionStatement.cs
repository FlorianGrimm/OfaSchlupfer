namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class RollbackTransactionStatement : TransactionStatement {
        public RollbackTransactionStatement() : base() { }
        public RollbackTransactionStatement(ScriptDom.RollbackTransactionStatement src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
