#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class WindowFrameClause : SqlNode {
        public WindowFrameClause() : base() { }
        public WindowFrameClause(ScriptDom.WindowFrameClause src) : base(src) {
            this.Top = Copier.Copy<WindowDelimiter>(src.Top);
            this.Bottom = Copier.Copy<WindowDelimiter>(src.Bottom);
            this.WindowFrameType = src.WindowFrameType;
        }
        public WindowDelimiter Top;
        public WindowDelimiter Bottom;
        public Microsoft.SqlServer.TransactSql.ScriptDom.WindowFrameType WindowFrameType;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Top?.Accept(visitor);
            this.Bottom?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
