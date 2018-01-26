namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class WithinGroupClause : SqlNode {
        public WithinGroupClause() : base() { }
        public WithinGroupClause(ScriptDom.WithinGroupClause src) : base(src) {
            this.OrderByClause = Copier.Copy<OrderByClause>(src.OrderByClause);
        }

        public OrderByClause OrderByClause { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OrderByClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
