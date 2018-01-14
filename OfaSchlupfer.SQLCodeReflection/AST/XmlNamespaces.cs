namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class XmlNamespaces : TSqlFragment {
        private List<XmlNamespacesElement> _xmlNamespacesElements = new List<XmlNamespacesElement>();

        public List<XmlNamespacesElement> XmlNamespacesElements {
            get {
                return this._xmlNamespacesElements;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.XmlNamespacesElements.Count; i < count; i++) {
                this.XmlNamespacesElements[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
