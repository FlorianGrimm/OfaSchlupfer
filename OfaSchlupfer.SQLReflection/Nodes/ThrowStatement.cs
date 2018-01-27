namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ThrowStatement : SqlStatement {
        public ThrowStatement() : base() { }
        public ThrowStatement(ScriptDom.ThrowStatement src) : base(src) {
            this.ErrorNumber = Copier.Copy<ValueExpression>(src.ErrorNumber);
            this.Message = Copier.Copy<ValueExpression>(src.Message);
            this.State = Copier.Copy<ValueExpression>(src.State);
        }

        public ValueExpression ErrorNumber { get; set; }

        public ValueExpression Message { get; set; }

        public ValueExpression State { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ErrorNumber?.Accept(visitor);
            this.Message?.Accept(visitor);
            this.State?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}