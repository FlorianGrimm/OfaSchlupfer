namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ProcedureStatementBodyBase : SqlStatement {
        public ProcedureStatementBodyBase() : base() { }
        public ProcedureStatementBodyBase(ScriptDom.ProcedureStatementBodyBase src) : base(src) {
            Copier.CopyList(this.Parameters, src.Parameters);
            this.StatementList = Copier.Copy<StatementList>(src.StatementList);
            this.MethodSpecifier = Copier.Copy<MethodSpecifier>(src.MethodSpecifier);
        }
        public List<ProcedureParameter> Parameters { get; } = new List<ProcedureParameter>();

        public StatementList StatementList { get; set; }

        public MethodSpecifier MethodSpecifier { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Parameters.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
