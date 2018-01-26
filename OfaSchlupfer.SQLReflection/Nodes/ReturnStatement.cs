namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ReturnStatement : SqlStatement {
        public ReturnStatement() : base() { }
        public ReturnStatement(ScriptDom.ReturnStatement src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }

        public ScalarExpression Expression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
