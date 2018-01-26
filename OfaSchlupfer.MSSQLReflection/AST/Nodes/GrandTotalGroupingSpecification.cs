#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class GrandTotalGroupingSpecification : GroupingSpecification {
        public GrandTotalGroupingSpecification() : base() { }
        public GrandTotalGroupingSpecification(ScriptDom.GrandTotalGroupingSpecification src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
