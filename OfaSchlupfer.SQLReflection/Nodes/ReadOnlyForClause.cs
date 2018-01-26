namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ReadOnlyForClause : ForClause {
        public ReadOnlyForClause() : base() { }
        public ReadOnlyForClause(ScriptDom.ReadOnlyForClause src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
