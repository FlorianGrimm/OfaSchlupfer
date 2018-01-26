namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class WhenClause : SqlNode {
        public WhenClause() : base() { }
        public WhenClause(ScriptDom.WhenClause src) : base(src) {
            this.ThenExpression = Copier.Copy<ScalarExpression>(src.ThenExpression);
        }

        public ScalarExpression ThenExpression { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ThenExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
