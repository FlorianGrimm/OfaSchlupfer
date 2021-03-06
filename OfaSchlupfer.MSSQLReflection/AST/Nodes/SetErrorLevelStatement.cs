#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SetErrorLevelStatement : SqlStatement {
        public SetErrorLevelStatement() : base() { }
        public SetErrorLevelStatement(ScriptDom.SetErrorLevelStatement src) : base(src) {
            this.Level = Copier.Copy<ScalarExpression>(src.Level);
        }
        public ScalarExpression Level;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Level?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
