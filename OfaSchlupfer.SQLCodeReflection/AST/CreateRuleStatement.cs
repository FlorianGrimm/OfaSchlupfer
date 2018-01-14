namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateRuleStatement : TSqlStatement {
        private SchemaObjectName _name;

        private BooleanExpression _expression;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public BooleanExpression Expression {
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
            if (this.Name != null) {
                this.Name.Accept(visitor);
            }
            if (this.Expression != null) {
                this.Expression.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
