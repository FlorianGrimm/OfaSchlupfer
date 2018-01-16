namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class InPredicate : BooleanExpression {
        private ScalarExpression _expression;

        private ScalarSubquery _subquery;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public ScalarSubquery Subquery {
            get {
                return this._subquery;
            }

            set {
                this.UpdateTokenInfo(value);
                this._subquery = value;
            }
        }

        public bool NotDefined { get; set; }

        public List<ScalarExpression> Values { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.Subquery?.Accept(visitor);
            this.Values.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
