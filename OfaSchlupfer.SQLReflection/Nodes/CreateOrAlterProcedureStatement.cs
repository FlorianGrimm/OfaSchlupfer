namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CreateOrAlterProcedureStatement : ProcedureStatementBody {
        public CreateOrAlterProcedureStatement() : base() { }
        public CreateOrAlterProcedureStatement(ScriptDom.CreateOrAlterProcedureStatement src) : base(src) {
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
