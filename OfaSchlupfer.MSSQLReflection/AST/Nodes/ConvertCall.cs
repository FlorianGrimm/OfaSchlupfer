#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ConvertCall : PrimaryExpression {
        public ConvertCall() : base() { }
        public ConvertCall(ScriptDom.ConvertCall src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
            this.Style = Copier.Copy<ScalarExpression>(src.Style);
        }
        public DataTypeReference DataType;
        public ScalarExpression Parameter;
        public ScalarExpression Style;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
            this.Style?.Accept(visitor);
        }
    }
}
