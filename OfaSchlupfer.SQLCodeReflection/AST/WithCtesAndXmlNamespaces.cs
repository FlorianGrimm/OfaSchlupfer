namespace OfaSchlupfer.AST {
    using System.Collections.Generic;
    [System.Serializable]
    public sealed class WithCtesAndXmlNamespaces : TSqlFragment {
        private XmlNamespaces _xmlNamespaces;

        private ValueExpression _changeTrackingContext;

        public XmlNamespaces XmlNamespaces {
            get {
                return this._xmlNamespaces;
            }

            set {
                this.UpdateTokenInfo(value);
                this._xmlNamespaces = value;
            }
        }

        public List<CommonTableExpression> CommonTableExpressions { get; } = new List<CommonTableExpression>();

        public ValueExpression ChangeTrackingContext {
            get {
                return this._changeTrackingContext;
            }

            set {
                this.UpdateTokenInfo(value);
                this._changeTrackingContext = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.XmlNamespaces?.Accept(visitor);
            this.CommonTableExpressions.Accept(visitor);
            this.ChangeTrackingContext?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
