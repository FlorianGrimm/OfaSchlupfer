#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class CommitTransactionStatement : TransactionStatement {
        public CommitTransactionStatement() : base() { }
        public CommitTransactionStatement(ScriptDom.CommitTransactionStatement src) : base(src) {
            this.DelayedDurabilityOption = src.DelayedDurabilityOption;
        }
        public ScriptDom.OptionState DelayedDurabilityOption;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
