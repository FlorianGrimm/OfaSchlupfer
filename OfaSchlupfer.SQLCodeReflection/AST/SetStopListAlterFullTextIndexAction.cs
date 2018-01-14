namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SetStopListAlterFullTextIndexAction : AlterFullTextIndexAction {
        private StopListFullTextIndexOption _stopListOption;

        public StopListFullTextIndexOption StopListOption {
            get {
                return this._stopListOption;
            }

            set {
                this.UpdateTokenInfo(value);
                this._stopListOption = value;
            }
        }

        public bool WithNoPopulation { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.StopListOption?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
