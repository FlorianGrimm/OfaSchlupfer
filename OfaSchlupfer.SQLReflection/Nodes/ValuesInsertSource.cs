namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ValuesInsertSource : InsertSource {
        public ValuesInsertSource() : base() { }
        public ValuesInsertSource(ScriptDom.ValuesInsertSource src) : base(src) {
            this.IsDefaultValues = src.IsDefaultValues;
            Copier.CopyList(this.RowValues, src.RowValues);
        }
        public bool IsDefaultValues { get; set; }

        public List<RowValue> RowValues { get; } = new List<RowValue>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.RowValues.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
