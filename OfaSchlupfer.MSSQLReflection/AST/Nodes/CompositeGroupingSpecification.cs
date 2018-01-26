#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class CompositeGroupingSpecification : GroupingSpecification {
        public CompositeGroupingSpecification() : base() { }
        public CompositeGroupingSpecification(ScriptDom.CompositeGroupingSpecification src) : base(src) {
            Copier.CopyList(this.Items, src.Items);
        }
        public List<GroupingSpecification> Items { get; } = new List<GroupingSpecification>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Items.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
