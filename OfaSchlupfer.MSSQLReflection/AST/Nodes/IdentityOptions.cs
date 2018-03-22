#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class IdentityOptions : SqlNode {
        public IdentityOptions() : base() { }
        public IdentityOptions(ScriptDom.IdentityOptions src) : base(src) {
            this.IdentitySeed = Copier.Copy<ScalarExpression>(src.IdentitySeed);
            this.IdentityIncrement = Copier.Copy<ScalarExpression>(src.IdentityIncrement);
            this.IsIdentityNotForReplication = src.IsIdentityNotForReplication;
        }
        public ScalarExpression IdentitySeed;
        public ScalarExpression IdentityIncrement;
        public bool IsIdentityNotForReplication;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.IdentitySeed?.Accept(visitor);
            this.IdentityIncrement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
