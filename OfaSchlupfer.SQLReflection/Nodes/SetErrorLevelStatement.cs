namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SetErrorLevelStatement : SqlStatement {
        public SetErrorLevelStatement() : base() { }
        public SetErrorLevelStatement(ScriptDom.SetErrorLevelStatement src) : base(src) {
            this.Level = Copier.Copy<ScalarExpression>(src.Level);
        }
        public ScalarExpression Level { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Level?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
