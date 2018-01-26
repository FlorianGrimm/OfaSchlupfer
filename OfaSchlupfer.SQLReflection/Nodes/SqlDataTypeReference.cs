namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SqlDataTypeReference : ParameterizedDataTypeReference {
        public SqlDataTypeReference() : base() { }
        public SqlDataTypeReference(ScriptDom.SqlDataTypeReference src) : base(src) {
            this.SqlDataTypeOption = src.SqlDataTypeOption;
        }

        /// <summary>
        /// COOOOL
        /// </summary>
        public Microsoft.SqlServer.TransactSql.ScriptDom.SqlDataTypeOption SqlDataTypeOption { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
