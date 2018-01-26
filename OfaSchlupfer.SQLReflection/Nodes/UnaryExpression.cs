namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class UnaryExpression : ScalarExpression {
        public UnaryExpression() : base() { }
        public UnaryExpression(ScriptDom.UnaryExpression src) : base(src) {
            this.UnaryExpressionType = src.UnaryExpressionType;
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.UnaryExpressionType UnaryExpressionType { get; set; }

        public ScalarExpression Expression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);


        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
