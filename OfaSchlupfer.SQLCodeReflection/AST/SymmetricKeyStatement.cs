namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class SymmetricKeyStatement : TSqlStatement {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<CryptoMechanism> EncryptingMechanisms { get; } = new List<CryptoMechanism>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.EncryptingMechanisms.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
