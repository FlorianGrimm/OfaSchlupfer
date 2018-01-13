namespace OfaSchlupfer.ScriptDom {
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
            if (this.Name != null) {
                this.Name.Accept(visitor);
            }
            int i = 0;
            for (int count = this.EncryptingMechanisms.Count; i < count; i++) {
                this.EncryptingMechanisms[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
