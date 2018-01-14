namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class MergeActionClause : TSqlFragment {
        private MergeCondition _condition;

        private BooleanExpression _searchCondition;

        private MergeAction _action;

        public MergeCondition Condition {
            get {
                return this._condition;
            }

            set {
                this._condition = value;
            }
        }

        public BooleanExpression SearchCondition {
            get {
                return this._searchCondition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._searchCondition = value;
            }
        }

        public MergeAction Action {
            get {
                return this._action;
            }

            set {
                this.UpdateTokenInfo(value);
                this._action = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SearchCondition?.Accept(visitor);
            this.Action?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
