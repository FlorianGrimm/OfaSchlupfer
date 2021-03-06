#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class WriteTextStatement : TextModificationStatement {
        public WriteTextStatement() : base() { }
        public WriteTextStatement(ScriptDom.WriteTextStatement src) : base(src) {
            this.SourceParameter = Copier.Copy<ValueExpression>(src.SourceParameter);
        }
        public ValueExpression SourceParameter;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SourceParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
