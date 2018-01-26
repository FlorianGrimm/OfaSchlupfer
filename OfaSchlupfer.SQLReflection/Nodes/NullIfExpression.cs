namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class NullIfExpression : PrimaryExpression {
        public NullIfExpression() : base() { }
        public NullIfExpression(ScriptDom.NullIfExpression src) : base(src) {
            this.FirstExpression = Copier.Copy<ScalarExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<ScalarExpression>(src.SecondExpression);
        }

        public ScalarExpression FirstExpression { get; set; }

        public ScalarExpression SecondExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
        }
    }
}
