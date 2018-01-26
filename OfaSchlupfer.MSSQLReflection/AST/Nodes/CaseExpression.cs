#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class CaseExpression : PrimaryExpression {
        public CaseExpression() : base() { }
        public CaseExpression(ScriptDom.CaseExpression src) : base(src) {
            this.ElseExpression = Copier.Copy<ScalarExpression>(src.ElseExpression);
        }

        public ScalarExpression ElseExpression { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ElseExpression?.Accept(visitor);
        }
    }
}
