#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ParenthesisExpression : PrimaryExpression {
        public ParenthesisExpression() : base() { }
        public ParenthesisExpression(ScriptDom.ParenthesisExpression src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }
        public ScalarExpression Expression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
        }
    }
}
