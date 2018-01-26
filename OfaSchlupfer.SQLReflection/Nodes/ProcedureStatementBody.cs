namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ProcedureStatementBody : ProcedureStatementBodyBase {
        public ProcedureStatementBody() : base() { }
        public ProcedureStatementBody(ScriptDom.ProcedureStatementBody src) : base(src) {
            this.ProcedureReference = Copier.Copy<ProcedureReference>(src.ProcedureReference);
            this.IsForReplication = src.IsForReplication;
        }

        public ProcedureReference ProcedureReference { get; set; }

        public bool IsForReplication { get; set; }

        // public List<ProcedureOption> Options { get; } = new List<ProcedureOption>();

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ProcedureReference?.Accept(visitor);
            // this.Options.Accept(visitor);
        }
    }
}
