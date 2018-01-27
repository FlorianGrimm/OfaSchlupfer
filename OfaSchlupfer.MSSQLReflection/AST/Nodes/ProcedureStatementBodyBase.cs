#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ProcedureStatementBodyBase : SqlStatement {
        public ProcedureStatementBodyBase() : base() { }
        public ProcedureStatementBodyBase(ScriptDom.ProcedureStatementBodyBase src) : base(src) {
            Copier.CopyList(this.Parameters, src.Parameters);
            this.StatementList = Copier.Copy<StatementList>(src.StatementList);
            this.MethodSpecifier = Copier.Copy<MethodSpecifier>(src.MethodSpecifier);
        }
        public List<ProcedureParameter> Parameters { get; } = new List<ProcedureParameter>();
        public StatementList StatementList;
        public MethodSpecifier MethodSpecifier;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Parameters.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
