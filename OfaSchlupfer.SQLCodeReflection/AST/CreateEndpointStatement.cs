namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateEndpointStatement : AlterCreateEndpointStatementBase, IAuthorization {
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
            this.Affinity?.Accept(visitor);
            this.ProtocolOptions.Accept(visitor);
            this.PayloadOptions.Accept(visitor);
            this.Owner?.Accept(visitor);
        }
    }
}
