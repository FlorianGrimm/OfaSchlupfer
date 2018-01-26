namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SimpleWhenClause : WhenClause {
        public SimpleWhenClause() : base() { }
        public SimpleWhenClause(ScriptDom.SimpleWhenClause src) : base(src) {
            this.WhenExpression = Copier.Copy<ScalarExpression>(src.WhenExpression);
        }

        public ScalarExpression WhenExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.WhenExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
