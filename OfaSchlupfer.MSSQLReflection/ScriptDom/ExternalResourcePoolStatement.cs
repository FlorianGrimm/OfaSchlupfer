namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ExternalResourcePoolStatement : TSqlStatement {
        private Identifier _name;

        private List<ExternalResourcePoolParameter> _externalResourcePoolParameters = new List<ExternalResourcePoolParameter>();

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ExternalResourcePoolParameter> ExternalResourcePoolParameters {
            get {
                return this._externalResourcePoolParameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i = 0, count = this.ExternalResourcePoolParameters.Count; i < count; i++) {
                this.ExternalResourcePoolParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
