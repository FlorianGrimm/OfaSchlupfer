#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class UserDefinedTypeCallTarget : CallTarget {
        public UserDefinedTypeCallTarget() : base() { }
        public UserDefinedTypeCallTarget(ScriptDom.UserDefinedTypeCallTarget src) : base(src) {
            this.SchemaObjectName = Copier.Copy<SchemaObjectName>(src.SchemaObjectName);
        }
        public SchemaObjectName SchemaObjectName;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}