namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class FetchType : TSqlFragment {
        private ScalarExpression _rowOffset;

        public FetchOrientation Orientation { get; set; }

        public ScalarExpression RowOffset {
            get {
                return this._rowOffset;
            }

            set {
                this.UpdateTokenInfo(value);
                this._rowOffset = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.RowOffset?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
