namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class XmlNamespaces : TSqlFragment {
        public List<XmlNamespacesElement> XmlNamespacesElements { get; } = new List<XmlNamespacesElement>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.XmlNamespacesElements.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
