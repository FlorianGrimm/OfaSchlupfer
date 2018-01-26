namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class GroupByClause : SqlNode {

        public GroupByClause() : base() { }
        public GroupByClause(ScriptDom.GroupByClause src) : base(src) {
            this.GroupByOption = src.GroupByOption;
            this.All = src.All;
            Copier.CopyList(this.GroupingSpecifications, src.GroupingSpecifications);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.GroupByOption GroupByOption { get; set; }

        public bool All { get; set; }

        public List<GroupingSpecification> GroupingSpecifications { get; } = new List<GroupingSpecification>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.GroupingSpecifications.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
