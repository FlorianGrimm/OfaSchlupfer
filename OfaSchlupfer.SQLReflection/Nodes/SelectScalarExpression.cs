namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SelectScalarExpression : SelectElement {
        public SelectScalarExpression() : base() { }
        public SelectScalarExpression(ScriptDom.SelectScalarExpression src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.ColumnName = Copier.Copy<IdentifierOrValueExpression>(src.ColumnName);
        }

        public ScalarExpression Expression { get; set; }

        public IdentifierOrValueExpression ColumnName { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.ColumnName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
