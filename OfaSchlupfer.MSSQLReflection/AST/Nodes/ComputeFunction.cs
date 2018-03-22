#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ComputeFunction : SqlNode {
        public ComputeFunction() : base() { }
        public ComputeFunction(ScriptDom.ComputeFunction src) : base(src) {
            this.ComputeFunctionType = src.ComputeFunctionType;
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ComputeFunctionType ComputeFunctionType;
        public ScalarExpression Expression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
