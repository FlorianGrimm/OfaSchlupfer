#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class WindowDelimiter : SqlNode {
        public WindowDelimiter() : base() { }
        public WindowDelimiter(ScriptDom.WindowDelimiter src) : base(src) {
            this.WindowDelimiterType = src.WindowDelimiterType;
            this.OffsetValue = Copier.Copy<ScalarExpression>(src.OffsetValue);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.WindowDelimiterType WindowDelimiterType;
        public ScalarExpression OffsetValue;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OffsetValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
