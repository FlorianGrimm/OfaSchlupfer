namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class InsertMergeAction : MergeAction {
        public InsertMergeAction() : base() { }
        public InsertMergeAction(ScriptDom.InsertMergeAction src) : base(src) {
            Copier.CopyList(this.Columns, src.Columns);
            this.Source = Copier.Copy<ValuesInsertSource>(src.Source);
        }

        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public ValuesInsertSource Source { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Columns.Accept(visitor);
            this.Source?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
