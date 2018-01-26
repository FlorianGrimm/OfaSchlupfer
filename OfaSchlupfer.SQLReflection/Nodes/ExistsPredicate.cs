namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class ExistsPredicate : BooleanExpression {
        public ExistsPredicate() : base() { }
        public ExistsPredicate(ScriptDom.ExistsPredicate src) : base(src) {
            this.Subquery = Copier.Copy<ScalarSubquery>(src.Subquery);
        }


        public ScalarSubquery Subquery { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Subquery?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
