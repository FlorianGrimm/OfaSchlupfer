namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExecuteParameter : TSqlFragment {
        private VariableReference _variable;

        private ScalarExpression _parameterValue;

        public VariableReference Variable {
            get {
                return this._variable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public ScalarExpression ParameterValue {
            get {
                return this._parameterValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameterValue = value;
            }
        }

        public bool IsOutput { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Variable != null) {
                this.Variable.Accept(visitor);
            }
            if (this.ParameterValue != null) {
                this.ParameterValue.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
