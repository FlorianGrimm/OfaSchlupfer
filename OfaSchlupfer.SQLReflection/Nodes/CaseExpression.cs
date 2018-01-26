namespace OfaSchlupfer.SQLReflection {
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
