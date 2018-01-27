#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ProcedureStatementBody : ProcedureStatementBodyBase {
        public ProcedureStatementBody() : base() { }
        public ProcedureStatementBody(ScriptDom.ProcedureStatementBody src) : base(src) {
            this.ProcedureReference = Copier.Copy<ProcedureReference>(src.ProcedureReference);
            this.IsForReplication = src.IsForReplication;
        }
        public ProcedureReference ProcedureReference;
        public bool IsForReplication;

        /*
        public List<ProcedureOption> Options { get; } = new List<ProcedureOption>();
         */
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ProcedureReference?.Accept(visitor);
            // this.Options.Accept(visitor);
        }
    }
}
