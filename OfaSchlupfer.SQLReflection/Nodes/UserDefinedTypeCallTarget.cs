namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class UserDefinedTypeCallTarget : CallTarget {
        public UserDefinedTypeCallTarget() : base() { }
        public UserDefinedTypeCallTarget(ScriptDom.UserDefinedTypeCallTarget src) : base(src) {
            this.SchemaObjectName = Copier.Copy<SchemaObjectName>(src.SchemaObjectName);
        }

        public SchemaObjectName SchemaObjectName { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
