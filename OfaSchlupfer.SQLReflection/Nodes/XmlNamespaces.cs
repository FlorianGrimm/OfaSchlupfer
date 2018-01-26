namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
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
