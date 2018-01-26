namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ExecutableProcedureReference : ExecutableEntity {
        public ExecutableProcedureReference() : base() { }
        public ExecutableProcedureReference(ScriptDom.ExecutableProcedureReference src) : base(src) {
            this.ProcedureReference = Copier.Copy<ProcedureReferenceName>(src.ProcedureReference);
        }

        public ProcedureReferenceName ProcedureReference { get; set; }

        // public AdHocDataSource AdHocDataSource { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ProcedureReference?.Accept(visitor);
            // this.AdHocDataSource?.Accept(visitor);
        }
    }
}
