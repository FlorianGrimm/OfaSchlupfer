namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ComputeFunction : TSqlFragment {
        private ComputeFunctionType _computeFunctionType;

        private ScalarExpression _expression;

        public ComputeFunctionType ComputeFunctionType {
            get {
                return this._computeFunctionType;
            }

            set {
                this._computeFunctionType = value;
            }
        }

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
