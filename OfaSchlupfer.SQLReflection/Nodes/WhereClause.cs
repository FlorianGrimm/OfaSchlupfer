namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class WhereClause : SqlNode {
        public WhereClause() : base() { }
        public WhereClause(ScriptDom.WhereClause src) : base(src) {
            this.SearchCondition = Copier.Copy<BooleanExpression>(src.SearchCondition);
            this.Cursor = Copier.Copy<CursorId>(src.Cursor);
        }
        public BooleanExpression SearchCondition { get; set; }

        public CursorId Cursor { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SearchCondition?.Accept(visitor);
            this.Cursor?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
