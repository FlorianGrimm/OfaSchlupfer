namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateRemoteServiceBindingStatement : RemoteServiceBindingStatementBase, IAuthorization {
        private Literal _service;

        private Identifier _owner;

        public Literal Service {
            get {
                return this._service;
            }

            set {
                this.UpdateTokenInfo(value);
                this._service = value;
            }
        }

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
            this.Service?.Accept(visitor);
            this.Options.Accept(visitor);
            this.Owner?.Accept(visitor);
        }
    }
}
