namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class TableNonClusteredIndexType : TableIndexType {
        public TableNonClusteredIndexType() : base() { }
        public TableNonClusteredIndexType(ScriptDom.TableNonClusteredIndexType src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
