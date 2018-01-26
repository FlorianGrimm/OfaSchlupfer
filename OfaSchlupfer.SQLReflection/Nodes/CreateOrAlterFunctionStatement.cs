namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CreateOrAlterFunctionStatement : FunctionStatementBody {
        public CreateOrAlterFunctionStatement() : base() { }
        public CreateOrAlterFunctionStatement(ScriptDom.CreateOrAlterFunctionStatement src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.ReturnType?.Accept(visitor);
            // this.Options.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            // this.OrderHint?.Accept(visitor);
        }
    }
}
