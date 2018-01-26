#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class InlineDerivedTable : TableReferenceWithAliasAndColumns {
        public InlineDerivedTable() : base() { }
        public InlineDerivedTable(ScriptDom.InlineDerivedTable src) : base(src) {
            Copier.CopyList(this.RowValues, src.RowValues);
        }
        public List<RowValue> RowValues { get; } = new List<RowValue>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.RowValues.Accept(visitor);
        }
    }
}
