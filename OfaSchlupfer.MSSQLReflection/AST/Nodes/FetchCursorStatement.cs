#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class FetchCursorStatement : CursorStatement {
        public FetchCursorStatement() : base() { }
        public FetchCursorStatement(ScriptDom.FetchCursorStatement src) : base(src) {
            this.FetchType = Copier.Copy<FetchType>(src.FetchType);
            Copier.CopyList(this.IntoVariables, src.IntoVariables);
        }
        public FetchType FetchType;
        public List<VariableReference> IntoVariables { get; } = new List<VariableReference>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FetchType?.Accept(visitor);
            this.IntoVariables.Accept(visitor);
        }
    }
}
