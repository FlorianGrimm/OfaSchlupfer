#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SetTransactionIsolationLevelStatement : SqlStatement {
        public SetTransactionIsolationLevelStatement() : base() { }
        public SetTransactionIsolationLevelStatement(ScriptDom.SetTransactionIsolationLevelStatement src) : base(src) {
            this.Level = src.Level;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.IsolationLevel Level;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
