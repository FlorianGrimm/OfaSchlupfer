namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CommonTableExpression : SqlNode {
        public CommonTableExpression() : base() { }
        public CommonTableExpression(ScriptDom.CommonTableExpression src) : base(src) {
            this.ExpressionName = Copier.Copy<Identifier>(src.ExpressionName);
            Copier.CopyList(this.Columns, src.Columns);
            this.QueryExpression = Copier.Copy<QueryExpression>(src.QueryExpression);
        }

        public Identifier ExpressionName { get; set; }

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public QueryExpression QueryExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ExpressionName?.Accept(visitor);
            this.Columns.Accept(visitor);
            this.QueryExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
