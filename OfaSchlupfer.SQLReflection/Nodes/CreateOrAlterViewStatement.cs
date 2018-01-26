namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CreateOrAlterViewStatement : ViewStatementBody {
        public CreateOrAlterViewStatement() : base() { }
        public CreateOrAlterViewStatement(ScriptDom.CreateOrAlterViewStatement src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
