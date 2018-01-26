namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ExpressionWithSortOrder : SqlNode {
        public ExpressionWithSortOrder() : base() { }
        public ExpressionWithSortOrder(ScriptDom.ExpressionWithSortOrder src) : base(src) {
            this.SortOrder = src.SortOrder;
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }

        public Microsoft.SqlServer.TransactSql.ScriptDom.SortOrder SortOrder { get; set; }

        public ScalarExpression Expression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
