namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExistsPredicate : BooleanExpression {
        private ScalarSubquery _subquery;

        public ScalarSubquery Subquery {
            get {
                return this._subquery;
            }

            set {
                this.UpdateTokenInfo(value);
                this._subquery = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Subquery?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
