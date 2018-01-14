namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ParameterlessCall : PrimaryExpression {
        private ParameterlessCallType _parameterlessCallType;

        public ParameterlessCallType ParameterlessCallType {
            get {
                return this._parameterlessCallType;
            }

            set {
                this._parameterlessCallType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
