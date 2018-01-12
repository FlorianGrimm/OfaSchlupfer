namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AutoCreateStatisticsDatabaseOption : OnOffDatabaseOption {
        private bool _hasIncremental;

        private OptionState _incrementalState;

        public bool HasIncremental {
            get {
                return this._hasIncremental;
            }
            set {
                this._hasIncremental = value;
            }
        }

        public OptionState IncrementalState {
            get {
                return this._incrementalState;
            }
            set {
                this._incrementalState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
