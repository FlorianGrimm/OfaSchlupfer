namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterProcedureStatement : ProcedureStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ProcedureReference?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.Options.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
        }
    }
}
