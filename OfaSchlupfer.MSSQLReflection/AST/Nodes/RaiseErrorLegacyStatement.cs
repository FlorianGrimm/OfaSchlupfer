#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class RaiseErrorLegacyStatement : SqlStatement {
        public RaiseErrorLegacyStatement() : base() { }
        public RaiseErrorLegacyStatement(ScriptDom.RaiseErrorLegacyStatement src) : base(src) {
            this.FirstParameter = Copier.Copy<ScalarExpression>(src.FirstParameter);
            this.SecondParameter = Copier.Copy<ValueExpression>(src.SecondParameter);
        }
        public ScalarExpression FirstParameter;
        public ValueExpression SecondParameter;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstParameter?.Accept(visitor);
            this.SecondParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
