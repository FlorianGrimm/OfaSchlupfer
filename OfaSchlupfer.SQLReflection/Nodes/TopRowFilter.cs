namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class TopRowFilter : SqlNode {
        public TopRowFilter() : base() { }
        public TopRowFilter(ScriptDom.TopRowFilter src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.Percent = src.Percent;
            this.WithTies = src.WithTies;
        }
        public ScalarExpression Expression { get; set; }
        public bool Percent { get; set; }

        public bool WithTies { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
