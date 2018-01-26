namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class OffsetClause : SqlNode {
        public OffsetClause() : base() { }
        public OffsetClause(ScriptDom.OffsetClause src) : base(src) {
            this.OffsetExpression = Copier.Copy<ScalarExpression>(src.OffsetExpression);
            this.FetchExpression = Copier.Copy<ScalarExpression>(src.FetchExpression);
        }

        public ScalarExpression OffsetExpression { get; set; }

        public ScalarExpression FetchExpression { get; set; }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OffsetExpression?.Accept(visitor);
            this.FetchExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
