namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class XmlNamespacesDefaultElement : XmlNamespacesElement {

        public XmlNamespacesDefaultElement() : base() { }
        public XmlNamespacesDefaultElement(ScriptDom.XmlNamespacesDefaultElement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
