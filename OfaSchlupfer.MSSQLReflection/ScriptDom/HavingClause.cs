namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class HavingClause : TSqlFragment {
        private BooleanExpression _searchCondition;

        public BooleanExpression SearchCondition {
            get {
                return this._searchCondition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._searchCondition = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SearchCondition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
