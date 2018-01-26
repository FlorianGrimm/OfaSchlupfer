#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SqlDataTypeReference : ParameterizedDataTypeReference {
        public SqlDataTypeReference() : base() { }
        public SqlDataTypeReference(ScriptDom.SqlDataTypeReference src) : base(src) {
            this.SqlDataTypeOption = src.SqlDataTypeOption;
        }

        /// <summary>
        /// Gets or sets cOOOOL
        /// </summary>
        public Microsoft.SqlServer.TransactSql.ScriptDom.SqlDataTypeOption SqlDataTypeOption { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
