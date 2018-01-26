#pragma warning disable SA1402
#pragma warning disable SA1600
#pragma warning disable SA1649

namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class OpenCursorStatement : CursorStatement {
        public OpenCursorStatement() : base() { }
        public OpenCursorStatement(ScriptDom.OpenCursorStatement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
