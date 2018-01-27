#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ValuesInsertSource : InsertSource {
        public ValuesInsertSource() : base() { }
        public ValuesInsertSource(ScriptDom.ValuesInsertSource src) : base(src) {
            this.IsDefaultValues = src.IsDefaultValues;
            Copier.CopyList(this.RowValues, src.RowValues);
        }
        public bool IsDefaultValues;
        public List<RowValue> RowValues { get; } = new List<RowValue>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.RowValues.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
