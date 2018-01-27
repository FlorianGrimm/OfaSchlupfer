#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SelectFunctionReturnType : FunctionReturnType {
        public SelectFunctionReturnType() : base() { }
        public SelectFunctionReturnType(ScriptDom.SelectFunctionReturnType src) : base(src) {
            this.SelectStatement = Copier.Copy<SelectStatement>(src.SelectStatement);
        }
        public SelectStatement SelectStatement;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SelectStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
