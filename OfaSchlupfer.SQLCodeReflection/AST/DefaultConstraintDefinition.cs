namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DefaultConstraintDefinition : ConstraintDefinition {
        private ScalarExpression _expression;
        
        private Identifier _column;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public bool WithValues { get; set; }

        public Identifier Column {
            get {
                return this._column;
            }

            set {
                this.UpdateTokenInfo(value);
                this._column = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.Expression != null) {
                this.Expression.Accept(visitor);
            }
            if (this.Column != null) {
                this.Column.Accept(visitor);
            }
        }
    }
}
