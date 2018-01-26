namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class UserDataTypeReference : ParameterizedDataTypeReference {
        public UserDataTypeReference() : base() { }
        public UserDataTypeReference(ScriptDom.UserDataTypeReference src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
