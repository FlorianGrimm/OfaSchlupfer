#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
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
