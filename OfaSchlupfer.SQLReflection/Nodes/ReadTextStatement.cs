namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ReadTextStatement : SqlStatement {
        public ReadTextStatement() : base() { }
        public ReadTextStatement(ScriptDom.ReadTextStatement src) : base(src) {
            this.Column = Copier.Copy<ColumnReferenceExpression>(src.Column);
            this.TextPointer = Copier.Copy<ValueExpression>(src.TextPointer);
            this.Offset = Copier.Copy<ValueExpression>(src.Offset);
            this.Size = Copier.Copy<ValueExpression>(src.Size);
            this.HoldLock = src.HoldLock;
        }

        public ColumnReferenceExpression Column { get; set; }

        public ValueExpression TextPointer { get; set; }

        public ValueExpression Offset { get; set; }

        public ValueExpression Size { get; set; }

        public bool HoldLock { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            this.TextPointer?.Accept(visitor);
            this.Offset?.Accept(visitor);
            this.Size?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
