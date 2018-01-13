namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExpressionGroupingSpecification : GroupingSpecification {
        private ScalarExpression _expression;

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
            if (this.Expression != null) {
                this.Expression.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
