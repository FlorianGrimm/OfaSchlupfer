namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
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
