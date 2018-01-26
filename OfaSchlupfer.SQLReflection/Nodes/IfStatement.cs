namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class IfStatement : SqlStatement {
        public IfStatement() : base() { }
        public IfStatement(ScriptDom.IfStatement src) : base(src) {
            this.Predicate = Copier.Copy<BooleanExpression>(src.Predicate);
            this.ThenStatement = Copier.Copy<SqlStatement>(src.ThenStatement);
            this.ElseStatement = Copier.Copy<SqlStatement>(src.ElseStatement);
        }

        public BooleanExpression Predicate { get; set; }

        public SqlStatement ThenStatement { get; set; }

        public SqlStatement ElseStatement { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Predicate?.Accept(visitor);
            this.ThenStatement?.Accept(visitor);
            this.ElseStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
