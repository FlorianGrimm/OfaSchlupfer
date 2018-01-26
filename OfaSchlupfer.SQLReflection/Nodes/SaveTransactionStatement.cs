namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SaveTransactionStatement : TransactionStatement {
        public SaveTransactionStatement() : base() { }
        public SaveTransactionStatement(ScriptDom.SaveTransactionStatement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
