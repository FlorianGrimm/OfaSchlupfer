#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
