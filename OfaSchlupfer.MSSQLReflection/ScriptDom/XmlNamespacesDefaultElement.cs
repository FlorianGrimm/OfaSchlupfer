namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class XmlNamespacesDefaultElement : XmlNamespacesElement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
