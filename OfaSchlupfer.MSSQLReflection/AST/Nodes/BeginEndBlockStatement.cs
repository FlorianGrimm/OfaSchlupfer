#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public class BeginEndBlockStatement : SqlStatement {
        public BeginEndBlockStatement() : base() { }
        public BeginEndBlockStatement(ScriptDom.BeginEndBlockStatement src) : base(src) {
            this.StatementList = Copier.Copy<StatementList>(src.StatementList);
        }
        public StatementList StatementList;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.StatementList?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
