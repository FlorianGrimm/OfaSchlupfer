#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class XmlNamespacesElement : SqlNode {
        public XmlNamespacesElement() : base() { }
        public XmlNamespacesElement(ScriptDom.XmlNamespacesElement src) : base(src) {
            this.String = Copier.Copy<StringLiteral>(src.String);
        }
        public StringLiteral String;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.String?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
