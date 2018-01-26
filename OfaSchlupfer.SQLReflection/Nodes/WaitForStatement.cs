namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class WaitForStatement : SqlStatement {
        public WaitForStatement() : base() { }
        public WaitForStatement(ScriptDom.WaitForStatement src) : base(src) {
            this.WaitForOption = src.WaitForOption;
            this.Parameter = Copier.Copy<ValueExpression>(src.Parameter);
            this.Timeout = Copier.Copy<ScalarExpression>(src.Timeout);
            this.Statement = Copier.Copy<WaitForSupportedStatement>(src.Statement);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.WaitForOption WaitForOption { get; set; }

        public ValueExpression Parameter { get; set; }

        public ScalarExpression Timeout { get; set; }

        public WaitForSupportedStatement Statement { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Parameter?.Accept(visitor);
            this.Timeout?.Accept(visitor);
            this.Statement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
