#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class GroupByClause : SqlNode {
        public GroupByClause() : base() { }
        public GroupByClause(ScriptDom.GroupByClause src) : base(src) {
            this.GroupByOption = src.GroupByOption;
            this.All = src.All;
            Copier.CopyList(this.GroupingSpecifications, src.GroupingSpecifications);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.GroupByOption GroupByOption;
        public bool All;
        public List<GroupingSpecification> GroupingSpecifications { get; } = new List<GroupingSpecification>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.GroupingSpecifications.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
