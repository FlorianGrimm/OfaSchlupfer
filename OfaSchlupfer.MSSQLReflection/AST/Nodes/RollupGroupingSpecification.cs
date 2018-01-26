#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class RollupGroupingSpecification : GroupingSpecification {
        public RollupGroupingSpecification() : base() { }
        public RollupGroupingSpecification(ScriptDom.RollupGroupingSpecification src) : base(src) {
            Copier.CopyList(this.Arguments, src.Arguments);
        }

        public List<GroupingSpecification> Arguments { get; } = new List<GroupingSpecification>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Arguments.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
