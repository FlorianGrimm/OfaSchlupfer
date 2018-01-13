namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;
    [System.Serializable]
    public sealed class WithCtesAndXmlNamespaces : TSqlFragment {
        private XmlNamespaces _xmlNamespaces;

        private List<CommonTableExpression> _commonTableExpressions = new List<CommonTableExpression>();

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

        public List<CommonTableExpression> CommonTableExpressions {
            get {
                return this._commonTableExpressions;
            }
        }

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
            for (int i = 0, count = this.CommonTableExpressions.Count; i < count; i++) {
                this.CommonTableExpressions[i].Accept(visitor);
            }
            this.ChangeTrackingContext?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
