#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
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
