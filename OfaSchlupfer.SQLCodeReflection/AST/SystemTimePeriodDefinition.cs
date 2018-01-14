namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SystemTimePeriodDefinition : TSqlFragment {
        private Identifier _startTimeColumn;

        private Identifier _endTimeColumn;

        public Identifier StartTimeColumn {
            get {
                return this._startTimeColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._startTimeColumn = value;
            }
        }

        public Identifier EndTimeColumn {
            get {
                return this._endTimeColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._endTimeColumn = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.StartTimeColumn?.Accept(visitor);
            this.EndTimeColumn?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
