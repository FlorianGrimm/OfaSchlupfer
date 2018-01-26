namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OrderByClause : SqlNode {
        public OrderByClause() : base() { }
        public OrderByClause(ScriptDom.OrderByClause src) : base(src) {
            Copier.CopyList(this.OrderByElements, src.OrderByElements);
        }
        public List<ExpressionWithSortOrder> OrderByElements { get; } = new List<ExpressionWithSortOrder>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OrderByElements.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
