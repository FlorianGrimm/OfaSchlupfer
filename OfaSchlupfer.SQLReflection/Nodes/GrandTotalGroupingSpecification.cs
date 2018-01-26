namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class GrandTotalGroupingSpecification : GroupingSpecification {
        public GrandTotalGroupingSpecification() : base() { }
        public GrandTotalGroupingSpecification(ScriptDom.GrandTotalGroupingSpecification src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
