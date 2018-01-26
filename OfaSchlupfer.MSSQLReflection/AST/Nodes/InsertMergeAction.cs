#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
