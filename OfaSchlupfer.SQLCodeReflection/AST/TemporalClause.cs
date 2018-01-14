namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class TemporalClause : TSqlFragment {
        private TemporalClauseType _temporalClauseType;

        private ScalarExpression _startTime;

        private ScalarExpression _endTime;

        public TemporalClauseType TemporalClauseType {
            get {
                return this._temporalClauseType;
            }

            set {
                this._temporalClauseType = value;
            }
        }

        public ScalarExpression StartTime {
            get {
                return this._startTime;
            }

            set {
                this.UpdateTokenInfo(value);
                this._startTime = value;
            }
        }

        public ScalarExpression EndTime {
            get {
                return this._endTime;
            }

            set {
                this.UpdateTokenInfo(value);
                this._endTime = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.StartTime?.Accept(visitor);
            this.EndTime?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
