#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class OverClause : SqlNode {
        public OverClause() : base() { }
        public OverClause(ScriptDom.OverClause src) : base(src) {
            Copier.CopyList(this.Partitions, src.Partitions);
            this.OrderByClause = Copier.Copy<OrderByClause>(src.OrderByClause);
            this.WindowFrameClause = Copier.Copy<WindowFrameClause>(src.WindowFrameClause);
        }

        public List<ScalarExpression> Partitions { get; } = new List<ScalarExpression>();

        public OrderByClause OrderByClause { get; set; }

        public WindowFrameClause WindowFrameClause { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Partitions.Accept(visitor);
            this.OrderByClause?.Accept(visitor);
            this.WindowFrameClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
