namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class XmlNamespacesAliasElement : XmlNamespacesElement {
        public XmlNamespacesAliasElement() : base() { }

        public XmlNamespacesAliasElement(ScriptDom.XmlNamespacesAliasElement src) : base(src) {
            this.Identifier = Copier.Copy<Identifier>(src.Identifier);
        }

        public Identifier Identifier { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Identifier?.Accept(visitor);
        }
    }
}
