namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class UserDefinedTypePropertyAccess : PrimaryExpression {
        public UserDefinedTypePropertyAccess() : base() { }
        public UserDefinedTypePropertyAccess(ScriptDom.UserDefinedTypePropertyAccess src) : base(src) {
            this.CallTarget = Copier.Copy<CallTarget>(src.CallTarget);
            this.PropertyName = Copier.Copy<Identifier>(src.PropertyName);
        }

        public CallTarget CallTarget { get; set; }

        public Identifier PropertyName { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CallTarget?.Accept(visitor);
            this.PropertyName?.Accept(visitor);
        }
    }
}
