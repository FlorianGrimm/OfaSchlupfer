#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class WaitForStatement : SqlStatement {
        public WaitForStatement() : base() { }
        public WaitForStatement(ScriptDom.WaitForStatement src) : base(src) {
            this.WaitForOption = src.WaitForOption;
            this.Parameter = Copier.Copy<ValueExpression>(src.Parameter);
            this.Timeout = Copier.Copy<ScalarExpression>(src.Timeout);
            this.Statement = Copier.Copy<WaitForSupportedStatement>(src.Statement);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.WaitForOption WaitForOption;
        public ValueExpression Parameter;
        public ScalarExpression Timeout;
        public WaitForSupportedStatement Statement;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Parameter?.Accept(visitor);
            this.Timeout?.Accept(visitor);
            this.Statement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
