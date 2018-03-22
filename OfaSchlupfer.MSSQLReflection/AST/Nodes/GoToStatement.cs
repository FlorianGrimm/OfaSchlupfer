#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class GoToStatement : SqlStatement {
        public GoToStatement() : base() { }
        public GoToStatement(ScriptDom.GoToStatement src) : base(src) {
            this.LabelName = Copier.Copy<Identifier>(src.LabelName);
        }
        public Identifier LabelName;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.LabelName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
