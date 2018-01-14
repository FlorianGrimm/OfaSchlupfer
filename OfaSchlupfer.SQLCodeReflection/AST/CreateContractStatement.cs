namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateContractStatement : TSqlStatement, IAuthorization {
        private Identifier _name;

        private Identifier _owner;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ContractMessage> Messages { get; } = new List<ContractMessage>();

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
            if (this.Name != null) {
                this.Name.Accept(visitor);
            }
            for (int i = 0, count = this.Messages.Count; i < count; i++) {
                this.Messages[i].Accept(visitor);
            }
            if (this.Owner != null) {
                this.Owner.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
