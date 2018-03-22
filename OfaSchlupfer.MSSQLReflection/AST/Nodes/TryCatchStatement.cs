#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class TryCatchStatement : SqlStatement {
        public TryCatchStatement() : base() { }
        public TryCatchStatement(ScriptDom.TryCatchStatement src) : base(src) {
            this.TryStatements = Copier.Copy<StatementList>(src.TryStatements);
            this.CatchStatements = Copier.Copy<StatementList>(src.CatchStatements);
        }
        public StatementList TryStatements;
        public StatementList CatchStatements;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.TryStatements?.Accept(visitor);
            this.CatchStatements?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
