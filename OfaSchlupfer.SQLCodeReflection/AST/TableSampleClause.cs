namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class TableSampleClause : TSqlFragment {
        private ScalarExpression _sampleNumber;

        private ScalarExpression _repeatSeed;

        public bool System { get; set; }

        public ScalarExpression SampleNumber {
            get {
                return this._sampleNumber;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sampleNumber = value;
            }
        }

        public TableSampleClauseOption TableSampleClauseOption { get; set; }

        public ScalarExpression RepeatSeed {
            get {
                return this._repeatSeed;
            }

            set {
                this.UpdateTokenInfo(value);
                this._repeatSeed = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SampleNumber?.Accept(visitor);
            this.RepeatSeed?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
