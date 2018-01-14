namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SelectScalarExpression : SelectElement {
        private ScalarExpression _expression;

        private IdentifierOrValueExpression _columnName;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public IdentifierOrValueExpression ColumnName {
            get {
                return this._columnName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._columnName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.ColumnName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
