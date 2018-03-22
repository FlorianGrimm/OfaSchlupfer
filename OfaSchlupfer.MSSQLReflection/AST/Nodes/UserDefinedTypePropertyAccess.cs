#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class UserDefinedTypePropertyAccess : PrimaryExpression {
        public UserDefinedTypePropertyAccess() : base() { }
        public UserDefinedTypePropertyAccess(ScriptDom.UserDefinedTypePropertyAccess src) : base(src) {
            this.CallTarget = Copier.Copy<CallTarget>(src.CallTarget);
            this.PropertyName = Copier.Copy<Identifier>(src.PropertyName);
        }
        public CallTarget CallTarget;
        public Identifier PropertyName;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CallTarget?.Accept(visitor);
            this.PropertyName?.Accept(visitor);
        }
    }
}
