namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateSymmetricKeyStatement : SymmetricKeyStatement, IAuthorization {
        private Identifier _provider;

        private Identifier _owner;

        public List<KeyOption> KeyOptions { get; } = new List<KeyOption>();

        public Identifier Provider {
            get {
                return this._provider;
            }

            set {
                this.UpdateTokenInfo(value);
                this._provider = value;
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
            this.KeyOptions.Accept(visitor);
            this.Provider?.Accept(visitor);
            this.EncryptingMechanisms.Accept(visitor);
            this.Owner?.Accept(visitor);
        }
    }
}
