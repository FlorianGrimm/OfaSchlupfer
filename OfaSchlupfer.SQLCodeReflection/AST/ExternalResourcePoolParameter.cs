namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExternalResourcePoolParameter : TSqlFragment {
        private ExternalResourcePoolParameterType _parameterType;

        private Literal _parameterValue;

        private ExternalResourcePoolAffinitySpecification _affinitySpecification;

        public ExternalResourcePoolParameterType ParameterType {
            get {
                return this._parameterType;
            }

            set {
                this._parameterType = value;
            }
        }

        public Literal ParameterValue {
            get {
                return this._parameterValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameterValue = value;
            }
        }

        public ExternalResourcePoolAffinitySpecification AffinitySpecification {
            get {
                return this._affinitySpecification;
            }

            set {
                this.UpdateTokenInfo(value);
                this._affinitySpecification = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ParameterValue?.Accept(visitor);
            this.AffinitySpecification?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
