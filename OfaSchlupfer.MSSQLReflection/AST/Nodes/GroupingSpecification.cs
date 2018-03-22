#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class GroupingSpecification : SqlNode {
        public GroupingSpecification() : base() { }
        public GroupingSpecification(ScriptDom.GroupingSpecification src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class GroupingSetsGroupingSpecification : GroupingSpecification {
        public GroupingSetsGroupingSpecification() : base() { }
        public GroupingSetsGroupingSpecification(ScriptDom.GroupingSetsGroupingSpecification src) : base(src) {
            Copier.CopyList(this.Sets, src.Sets);
        }
        public List<GroupingSpecification> Sets { get; } = new List<GroupingSpecification>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Sets.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
