namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class IdentityOptions : SqlNode {
        public IdentityOptions() : base() { }
        public IdentityOptions(ScriptDom.IdentityOptions src) : base(src) {
            this.IdentitySeed = Copier.Copy<ScalarExpression>(src.IdentitySeed);
            this.IdentityIncrement = Copier.Copy<ScalarExpression>(src.IdentityIncrement);
            this.IsIdentityNotForReplication = src.IsIdentityNotForReplication;
        }
        public ScalarExpression IdentitySeed { get; set; }

        public ScalarExpression IdentityIncrement { get; set; }

        public bool IsIdentityNotForReplication { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.IdentitySeed?.Accept(visitor);
            this.IdentityIncrement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
