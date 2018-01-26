#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public abstract class FunctionStatementBody : ProcedureStatementBodyBase {
        public FunctionStatementBody() : base() { }
        public FunctionStatementBody(ScriptDom.FunctionStatementBody src) : base(src) {
            this.Name = Copier.Copy<SchemaObjectName>(src.Name);
            this.ReturnType = Copier.Copy<FunctionReturnType>(src.ReturnType);
        }
        public SchemaObjectName Name { get; set; }

        public FunctionReturnType ReturnType { get; set; }

        /*
          public List<FunctionOption> Options { get; } = new List<FunctionOption>();
          public OrderBulkInsertOption OrderHint { get; set; }
        */

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
            this.ReturnType?.Accept(visitor);
            // this.Options.Accept(visitor);
            // this.OrderHint?.Accept(visitor);
        }
    }
}
