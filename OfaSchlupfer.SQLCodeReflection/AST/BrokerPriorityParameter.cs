namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class BrokerPriorityParameter : TSqlFragment {
        private BrokerPriorityParameterSpecialType _isDefaultOrAny;

        private BrokerPriorityParameterType _parameterType;

        private IdentifierOrValueExpression _parameterValue;

        public BrokerPriorityParameterSpecialType IsDefaultOrAny {
            get {
                return this._isDefaultOrAny;
            }

            set {
                this._isDefaultOrAny = value;
            }
        }

        public BrokerPriorityParameterType ParameterType {
            get {
                return this._parameterType;
            }

            set {
                this._parameterType = value;
            }
        }

        public IdentifierOrValueExpression ParameterValue {
            get {
                return this._parameterValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameterValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ParameterValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
