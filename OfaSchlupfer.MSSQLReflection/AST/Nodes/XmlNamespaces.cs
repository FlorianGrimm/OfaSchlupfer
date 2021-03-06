#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class XmlNamespaces : SqlNode {
        public XmlNamespaces() : base() { }
        public XmlNamespaces(ScriptDom.XmlNamespaces src) : base(src) {
            Copier.CopyList(this.XmlNamespacesElements, src.XmlNamespacesElements);
        }
        public List<XmlNamespacesElement> XmlNamespacesElements { get; } = new List<XmlNamespacesElement>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.XmlNamespacesElements.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
