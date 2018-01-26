namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class ParenthesisExpression : PrimaryExpression {
        public ParenthesisExpression() : base() { }
        public ParenthesisExpression(ScriptDom.ParenthesisExpression src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }
        public ScalarExpression Expression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
        }
    }
}
