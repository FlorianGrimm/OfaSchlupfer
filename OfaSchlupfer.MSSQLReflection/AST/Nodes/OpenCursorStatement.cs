#pragma warning disable SA1402
#pragma warning disable SA1600
#pragma warning disable SA1649

#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class OpenCursorStatement : CursorStatement {
        public OpenCursorStatement() : base() { }
        public OpenCursorStatement(ScriptDom.OpenCursorStatement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
