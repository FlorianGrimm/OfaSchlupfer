namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class UpdateTextStatement : TextModificationStatement {
        public UpdateTextStatement() : base() { }
        public UpdateTextStatement(ScriptDom.UpdateTextStatement src) : base(src) {
            this.InsertOffset = Copier.Copy<ScalarExpression>(src.InsertOffset);
            this.DeleteLength = Copier.Copy<ScalarExpression>(src.DeleteLength);
            this.SourceColumn = Copier.Copy<ColumnReferenceExpression>(src.SourceColumn);
            this.SourceParameter = Copier.Copy<ValueExpression>(src.SourceParameter);
        }
        public ScalarExpression InsertOffset { get; set; }

        public ScalarExpression DeleteLength { get; set; }

        public ColumnReferenceExpression SourceColumn { get; set; }

        public ValueExpression SourceParameter { get; set; }

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
