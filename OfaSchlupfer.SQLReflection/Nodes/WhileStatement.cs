namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class WhileStatement : SqlStatement {
        public WhileStatement() : base() { }
        public WhileStatement(ScriptDom.WhileStatement src) : base(src) {
            this.Predicate = Copier.Copy<BooleanExpression>(src.Predicate);
            this.Statement = Copier.Copy<SqlStatement>(src.Statement);
        }

        public BooleanExpression Predicate { get; set; }

        public SqlStatement Statement { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Predicate?.Accept(visitor);
            this.Statement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
