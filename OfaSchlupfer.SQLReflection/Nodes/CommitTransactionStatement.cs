namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CommitTransactionStatement : TransactionStatement {
        public CommitTransactionStatement() : base() { }
        public CommitTransactionStatement(ScriptDom.CommitTransactionStatement src) : base(src) {
            this.DelayedDurabilityOption = src.DelayedDurabilityOption;
        }


        public ScriptDom.OptionState DelayedDurabilityOption { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
