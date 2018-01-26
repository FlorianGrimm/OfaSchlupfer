namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SetRowCountStatement : SqlStatement {
        public SetRowCountStatement() : base() { }
        public SetRowCountStatement(ScriptDom.SetRowCountStatement src) : base(src) {
            this.NumberRows = Copier.Copy<ValueExpression>(src.NumberRows);
        }

        public ValueExpression NumberRows { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.NumberRows?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
