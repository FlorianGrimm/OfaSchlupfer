namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

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
