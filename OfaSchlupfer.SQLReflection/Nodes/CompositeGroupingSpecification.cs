namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

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
