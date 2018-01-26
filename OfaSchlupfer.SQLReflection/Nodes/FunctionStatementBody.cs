namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class FunctionStatementBody : ProcedureStatementBodyBase {
        public FunctionStatementBody() : base() { }
        public FunctionStatementBody(ScriptDom.FunctionStatementBody src) : base(src) {
            this.Name = Copier.Copy<SchemaObjectName>(src.Name);
            this.ReturnType = Copier.Copy<FunctionReturnType>(src.ReturnType);
        }
        public SchemaObjectName Name { get; set; }

        public FunctionReturnType ReturnType { get; set; }

        // public List<FunctionOption> Options { get; } = new List<FunctionOption>();

        // public OrderBulkInsertOption OrderHint { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
            this.ReturnType?.Accept(visitor);
            //        this.Options.Accept(visitor);
            //this.OrderHint?.Accept(visitor);
        }
    }
}
