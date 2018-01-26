namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CreateProcedureStatement : ProcedureStatementBody {
        public CreateProcedureStatement() : base() { }
        public CreateProcedureStatement(ScriptDom.CreateProcedureStatement src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ProcedureReference?.Accept(visitor);
            this.Parameters.Accept(visitor);
            // this.Options.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
        }
    }
}
