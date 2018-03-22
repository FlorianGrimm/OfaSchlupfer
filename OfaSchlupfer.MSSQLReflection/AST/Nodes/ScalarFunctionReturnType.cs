#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ScalarFunctionReturnType : FunctionReturnType {
        public ScalarFunctionReturnType() : base() { }
        public ScalarFunctionReturnType(ScriptDom.ScalarFunctionReturnType src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
        }
        public DataTypeReference DataType;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.DataType?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
