namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ProcedureReferenceName : SqlNode {
        public ProcedureReferenceName() : base() { }
        public ProcedureReferenceName(ScriptDom.ProcedureReferenceName src) : base(src) {
            this.ProcedureReference = Copier.Copy<ProcedureReference>(src.ProcedureReference);
            this.ProcedureVariable = Copier.Copy<VariableReference>(src.ProcedureVariable);
        }

        public ProcedureReference ProcedureReference { get; set; }

        public VariableReference ProcedureVariable { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ProcedureReference?.Accept(visitor);
            this.ProcedureVariable?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
