#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SetRowCountStatement : SqlStatement {
        public SetRowCountStatement() : base() { }
        public SetRowCountStatement(ScriptDom.SetRowCountStatement src) : base(src) {
            this.NumberRows = Copier.Copy<ValueExpression>(src.NumberRows);
        }
        public ValueExpression NumberRows;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.NumberRows?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
