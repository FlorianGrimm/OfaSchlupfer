namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateServiceStatement : AlterCreateServiceStatementBase, IAuthorization {
        private Identifier _owner;

        public Identifier Owner {
            get {
                return this._owner;
            }

            set {
                this.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.QueueName?.Accept(visitor);
            this.ServiceContracts.Accept(visitor);
            this.Owner?.Accept(visitor);
        }
    }
}
