namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SearchedWhenClause : WhenClause {
        private BooleanExpression _whenExpression;

        public BooleanExpression WhenExpression {
            get {
                return this._whenExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._whenExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.WhenExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
