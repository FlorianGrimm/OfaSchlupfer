#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ParameterlessCall : PrimaryExpression {
        public ParameterlessCall() : base() { }
        public ParameterlessCall(ScriptDom.ParameterlessCall src) : base(src) {
            this.ParameterlessCallType = src.ParameterlessCallType;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ParameterlessCallType ParameterlessCallType;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
