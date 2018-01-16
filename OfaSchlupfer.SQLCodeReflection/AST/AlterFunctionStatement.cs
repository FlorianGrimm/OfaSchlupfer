namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterFunctionStatement : FunctionStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.ReturnType?.Accept(visitor);
            this.Options?.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            this.OrderHint?.Accept(visitor);
        }
    }
}
