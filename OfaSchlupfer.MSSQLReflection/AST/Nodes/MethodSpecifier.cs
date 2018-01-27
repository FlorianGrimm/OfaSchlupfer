#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class MethodSpecifier : SqlNode {
        public MethodSpecifier() : base() { }
        public MethodSpecifier(ScriptDom.MethodSpecifier src) : base(src) {
            this.AssemblyName = Copier.Copy<Identifier>(src.AssemblyName);
            this.ClassName = Copier.Copy<Identifier>(src.ClassName);
            this.MethodName = Copier.Copy<Identifier>(src.MethodName);
        }
        public Identifier AssemblyName;
        public Identifier ClassName;
        public Identifier MethodName;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.AssemblyName?.Accept(visitor);
            this.ClassName?.Accept(visitor);
            this.MethodName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
