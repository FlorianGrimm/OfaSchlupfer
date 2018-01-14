namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateFunctionStatement : FunctionStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            int i = 0;
            for (int count = base.Parameters.Count; i < count; i++) {
                base.Parameters[i].Accept(visitor);
            }
            if (base.ReturnType != null) {
                base.ReturnType.Accept(visitor);
            }
            int j = 0;
            for (int count2 = base.Options.Count; j < count2; j++) {
                base.Options[j].Accept(visitor);
            }
            if (base.StatementList != null) {
                base.StatementList.Accept(visitor);
            }
            if (base.MethodSpecifier != null) {
                base.MethodSpecifier.Accept(visitor);
            }
            if (base.OrderHint != null) {
                base.OrderHint.Accept(visitor);
            }
        }
    }
}
