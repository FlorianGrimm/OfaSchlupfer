namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SqlCommandIdentifier : Identifier {
        public SqlCommandIdentifier() : base() { }
        public SqlCommandIdentifier(ScriptDom.SqlCommandIdentifier src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
