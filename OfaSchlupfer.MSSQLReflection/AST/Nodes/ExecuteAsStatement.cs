#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExecuteAsStatement : SqlStatement {
        public ExecuteAsStatement() : base() { }
        public ExecuteAsStatement(ScriptDom.ExecuteAsStatement src) : base(src) {
            this.WithNoRevert = src.WithNoRevert;
            this.Cookie = Copier.Copy<VariableReference>(src.Cookie);
            this.ExecuteContext = Copier.Copy<ExecuteContext>(src.ExecuteContext);
        }
        public bool WithNoRevert;
        public VariableReference Cookie;
        public ExecuteContext ExecuteContext;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Cookie?.Accept(visitor);
            this.ExecuteContext?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
