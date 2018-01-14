namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DeleteStatement : DataModificationStatement {
        private DeleteSpecification _deleteSpecification;

        public DeleteSpecification DeleteSpecification {
            get {
                return this._deleteSpecification;
            }

            set {
                this.UpdateTokenInfo(value);
                this._deleteSpecification = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.DeleteSpecification != null) {
                this.DeleteSpecification.Accept(visitor);
            }
        }
    }
}
