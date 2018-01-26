namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class TryCatchStatement : SqlStatement {
        public TryCatchStatement() : base() { }
        public TryCatchStatement(ScriptDom.TryCatchStatement src) : base(src) {
            this.TryStatements = Copier.Copy<StatementList>(src.TryStatements);
            this.CatchStatements = Copier.Copy<StatementList>(src.CatchStatements);
        }

        public StatementList TryStatements { get; set; }

        public StatementList CatchStatements { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.TryStatements?.Accept(visitor);
            this.CatchStatements?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
