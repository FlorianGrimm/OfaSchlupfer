namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class MergeActionClause : SqlNode {
        public MergeActionClause() : base() { }
        public MergeActionClause(ScriptDom.MergeActionClause src) : base(src) {
            this.Condition = src.Condition;
            this.SearchCondition = Copier.Copy<BooleanExpression>(src.SearchCondition);
            this.Action = Copier.Copy<MergeAction>(src.Action);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.MergeCondition Condition { get; set; }

        public BooleanExpression SearchCondition { get; set; }

        public MergeAction Action { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SearchCondition?.Accept(visitor);
            this.Action?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
