#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class TSqlStatementSnippet : SqlStatement {
        public TSqlStatementSnippet() : base() { }
        public TSqlStatementSnippet(ScriptDom.TSqlStatementSnippet src) : base(src) {
            this.Script = src.Script;
        }
        public string Script;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}