namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class XmlNamespacesElement : SqlNode {

        public XmlNamespacesElement() : base() { }
        public XmlNamespacesElement(ScriptDom.XmlNamespacesElement src) : base(src) {
            this.String = Copier.Copy<StringLiteral>(src.String);
        }
        public StringLiteral String { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.String?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
