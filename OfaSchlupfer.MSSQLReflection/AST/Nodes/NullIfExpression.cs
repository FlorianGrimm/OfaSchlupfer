#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class NullIfExpression : PrimaryExpression {
        public NullIfExpression() : base() { }
        public NullIfExpression(ScriptDom.NullIfExpression src) : base(src) {
            this.FirstExpression = Copier.Copy<ScalarExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<ScalarExpression>(src.SecondExpression);
        }
        public ScalarExpression FirstExpression;
        public ScalarExpression SecondExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
        }
    }
}
