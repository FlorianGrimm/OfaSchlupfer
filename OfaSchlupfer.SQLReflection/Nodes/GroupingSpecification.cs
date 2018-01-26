namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class GroupingSpecification : SqlNode {
        public GroupingSpecification() : base() { }
        public GroupingSpecification(ScriptDom.GroupingSpecification src) : base(src) {
        }
    }
}
namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
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
