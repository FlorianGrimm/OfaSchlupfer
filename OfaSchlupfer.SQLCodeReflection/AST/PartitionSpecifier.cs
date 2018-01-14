namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class PartitionSpecifier : TSqlFragment {
        private ScalarExpression _number;

        public ScalarExpression Number {
            get {
                return this._number;
            }

            set {
                this.UpdateTokenInfo(value);
                this._number = value;
            }
        }

        public bool All { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Number?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
