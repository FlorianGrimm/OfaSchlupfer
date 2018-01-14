namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class WorkloadGroupResourceParameter : WorkloadGroupParameter {
        private Literal _parameterValue;

        public Literal ParameterValue {
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
            base.AcceptChildren(visitor);
            this.ParameterValue?.Accept(visitor);
        }
    }
}
