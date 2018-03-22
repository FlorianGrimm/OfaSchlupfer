#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class OutputClause : SqlNode {
        public OutputClause() : base() { }
        public OutputClause(ScriptDom.OutputClause src) : base(src) {
            Copier.CopyList(this.SelectColumns, src.SelectColumns);
        }
        public List<SelectElement> SelectColumns { get; } = new List<SelectElement>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SelectColumns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
