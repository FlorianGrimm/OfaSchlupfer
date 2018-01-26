namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ExpressionCallTarget : CallTarget {
        public ExpressionCallTarget() : base() { }
        public ExpressionCallTarget(ScriptDom.ExpressionCallTarget src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }

        public ScalarExpression Expression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
