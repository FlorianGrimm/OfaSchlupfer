#pragma warning disable SA1128
#pragma warning disable SA1600

#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class AlterFunctionStatement : FunctionStatementBody {
        public AlterFunctionStatement() : base() { }
        public AlterFunctionStatement(ScriptDom.AlterFunctionStatement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.ReturnType?.Accept(visitor);
            // this.Options?.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            // this.OrderHint?.Accept(visitor);
        }
    }
}
