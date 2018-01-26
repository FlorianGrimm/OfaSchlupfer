namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ScalarSubquery : PrimaryExpression {
        public ScalarSubquery() : base() { }
        public ScalarSubquery(ScriptDom.ScalarSubquery src) : base(src) {
            this.QueryExpression = Copier.Copy<QueryExpression>(src.QueryExpression);
        }

        public QueryExpression QueryExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.QueryExpression?.Accept(visitor);
        }
    }
}
