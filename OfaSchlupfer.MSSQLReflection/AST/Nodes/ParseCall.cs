#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ParseCall : PrimaryExpression {
        public ParseCall() : base() { }
        public ParseCall(ScriptDom.ParseCall src) : base(src) {
            this.StringValue = Copier.Copy<ScalarExpression>(src.StringValue);
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Culture = Copier.Copy<ScalarExpression>(src.Culture);
        }
        public ScalarExpression StringValue;
        public DataTypeReference DataType;
        public ScalarExpression Culture;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StringValue?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Culture?.Accept(visitor);
        }
    }
}
