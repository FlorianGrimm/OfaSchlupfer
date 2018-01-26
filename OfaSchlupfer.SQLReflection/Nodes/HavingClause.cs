namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class HavingClause : SqlNode {
        public HavingClause() : base() { }
        public HavingClause(ScriptDom.HavingClause src) : base(src) {
            this.SearchCondition = Copier.Copy<BooleanExpression>(src.SearchCondition);
        }

        public BooleanExpression SearchCondition { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SearchCondition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
