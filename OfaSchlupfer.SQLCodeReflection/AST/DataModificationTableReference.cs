namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DataModificationTableReference : TableReferenceWithAliasAndColumns {
        private DataModificationSpecification _dataModificationSpecification;

        public DataModificationSpecification DataModificationSpecification {
            get {
                return this._dataModificationSpecification;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataModificationSpecification = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.DataModificationSpecification != null) {
                this.DataModificationSpecification.Accept(visitor);
            }
        }
    }
}
