namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterColumnAlterFullTextIndexAction : AlterFullTextIndexAction {
        private FullTextIndexColumn _column;

        public FullTextIndexColumn Column {
            get {
                return this._column;
            }

            set {
                this.UpdateTokenInfo(value);
                this._column = value;
            }
        }

        public bool WithNoPopulation { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
