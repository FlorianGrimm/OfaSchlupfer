#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class RowValue : SqlNode {
        public RowValue() : base() { }
        public RowValue(ScriptDom.RowValue src) : base(src) {
            Copier.CopyList(this.ColumnValues, src.ColumnValues);
        }
        public List<ScalarExpression> ColumnValues { get; } = new List<ScalarExpression>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ColumnValues.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
