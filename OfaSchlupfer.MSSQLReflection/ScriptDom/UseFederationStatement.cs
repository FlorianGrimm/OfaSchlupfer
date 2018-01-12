using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UseFederationStatement : TSqlStatement {
        private Identifier _federationName;

        private Identifier _distributionName;

        private ScalarExpression _value;

        private bool _filtering;

        public Identifier FederationName {
            get {
                return this._federationName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._federationName = value;
            }
        }

        public Identifier DistributionName {
            get {
                return this._distributionName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._distributionName = value;
            }
        }

        public ScalarExpression Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public bool Filtering {
            get {
                return this._filtering;
            }
            set {
                this._filtering = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FederationName?.Accept(visitor);
            this.DistributionName?.Accept(visitor);
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
