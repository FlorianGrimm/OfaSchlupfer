namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
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
