namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;
    [System.Serializable]
    public sealed class WithCtesAndXmlNamespaces : SqlNode {
        public WithCtesAndXmlNamespaces() : base() { }
        public WithCtesAndXmlNamespaces(ScriptDom.WithCtesAndXmlNamespaces src) : base(src) {
            this.XmlNamespaces = Copier.Copy<XmlNamespaces>(src.XmlNamespaces);
            Copier.CopyList(this.CommonTableExpressions, src.CommonTableExpressions);
            this.ChangeTrackingContext = Copier.Copy<ValueExpression>(src.ChangeTrackingContext);
        }

        public XmlNamespaces XmlNamespaces { get; set; }

        public List<CommonTableExpression> CommonTableExpressions { get; } = new List<CommonTableExpression>();

        public ValueExpression ChangeTrackingContext { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.XmlNamespaces?.Accept(visitor);
            this.CommonTableExpressions.Accept(visitor);
            this.ChangeTrackingContext?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
