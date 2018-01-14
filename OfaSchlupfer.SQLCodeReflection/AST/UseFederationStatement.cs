namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class UseFederationStatement : TSqlStatement {
        private Identifier _federationName;

        private Identifier _distributionName;

        private ScalarExpression _value;

        public Identifier FederationName {
            get {
                return this._federationName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._federationName = value;
            }
        }

        public Identifier DistributionName {
            get {
                return this._distributionName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._distributionName = value;
            }
        }

        public ScalarExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public bool Filtering { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FederationName?.Accept(visitor);
            this.DistributionName?.Accept(visitor);
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
