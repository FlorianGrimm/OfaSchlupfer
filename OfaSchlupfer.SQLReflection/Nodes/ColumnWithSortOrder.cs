namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class ColumnWithSortOrder : SqlNode {
        public ColumnWithSortOrder() : base() { }
        public ColumnWithSortOrder(ScriptDom.ColumnWithSortOrder src) : base(src) {
            this.Column = Copier.Copy<ColumnReferenceExpression>(src.Column);
        }
        public ColumnReferenceExpression Column { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.SortOrder SortOrder { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
