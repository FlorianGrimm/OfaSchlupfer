namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UpdateForClause : ForClause {
        public UpdateForClause() : base() { }
        public UpdateForClause(ScriptDom.UpdateForClause src) : base(src) {
            Copier.CopyList(this.Columns, src.Columns);
        }
        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
