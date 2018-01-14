namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class MultiPartIdentifierCallTarget : CallTarget {
        private MultiPartIdentifier _multiPartIdentifier;

        public MultiPartIdentifier MultiPartIdentifier {
            get {
                return this._multiPartIdentifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._multiPartIdentifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.MultiPartIdentifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
