#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class UpdateTextStatement : TextModificationStatement {
        public UpdateTextStatement() : base() { }
        public UpdateTextStatement(ScriptDom.UpdateTextStatement src) : base(src) {
            this.InsertOffset = Copier.Copy<ScalarExpression>(src.InsertOffset);
            this.DeleteLength = Copier.Copy<ScalarExpression>(src.DeleteLength);
            this.SourceColumn = Copier.Copy<ColumnReferenceExpression>(src.SourceColumn);
            this.SourceParameter = Copier.Copy<ValueExpression>(src.SourceParameter);
        }
        public ScalarExpression InsertOffset;
        public ScalarExpression DeleteLength;
        public ColumnReferenceExpression SourceColumn;
        public ValueExpression SourceParameter;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.InsertOffset?.Accept(visitor);
            this.DeleteLength?.Accept(visitor);
            this.SourceColumn?.Accept(visitor);
            this.SourceParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
