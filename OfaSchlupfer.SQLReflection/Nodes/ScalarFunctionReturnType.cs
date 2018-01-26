namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ScalarFunctionReturnType : FunctionReturnType {
        public ScalarFunctionReturnType() : base() { }
        public ScalarFunctionReturnType(ScriptDom.ScalarFunctionReturnType src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
        }

        public DataTypeReference DataType { get; set; }


        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.DataType?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
