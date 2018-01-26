#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
