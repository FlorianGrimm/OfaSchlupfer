namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class RaiseErrorLegacyStatement : SqlStatement {
        public RaiseErrorLegacyStatement() : base() { }
        public RaiseErrorLegacyStatement(ScriptDom.RaiseErrorLegacyStatement src) : base(src) {
            this.FirstParameter = Copier.Copy<ScalarExpression>(src.FirstParameter);
            this.SecondParameter = Copier.Copy<ValueExpression>(src.SecondParameter);
        }

        public ScalarExpression FirstParameter { get; set; }

        public ValueExpression SecondParameter { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstParameter?.Accept(visitor);
            this.SecondParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
