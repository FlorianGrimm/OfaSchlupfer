namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OffsetClause : TSqlFragment {
        private ScalarExpression _offsetExpression;

        private ScalarExpression _fetchExpression;

        public ScalarExpression OffsetExpression {
            get {
                return this._offsetExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._offsetExpression = value;
            }
        }

        public ScalarExpression FetchExpression {
            get {
                return this._fetchExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fetchExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OffsetExpression?.Accept(visitor);
            this.FetchExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
