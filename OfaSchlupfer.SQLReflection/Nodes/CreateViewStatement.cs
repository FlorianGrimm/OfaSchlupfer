namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CreateViewStatement : ViewStatementBody {
        public CreateViewStatement() : base() { }
        public CreateViewStatement(ScriptDom.CreateViewStatement src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
