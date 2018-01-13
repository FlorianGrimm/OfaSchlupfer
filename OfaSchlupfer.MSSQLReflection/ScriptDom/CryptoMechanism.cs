namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CryptoMechanism : TSqlFragment {
        private CryptoMechanismType _cryptoMechanismType;

        private Identifier _identifier;

        private Literal _passwordOrSignature;

        public CryptoMechanismType CryptoMechanismType {
            get {
                return this._cryptoMechanismType;
            }

            set {
                this._cryptoMechanismType = value;
            }
        }

        public Identifier Identifier {
            get {
                return this._identifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public Literal PasswordOrSignature {
            get {
                return this._passwordOrSignature;
            }

            set {
                this.UpdateTokenInfo(value);
                this._passwordOrSignature = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            this.PasswordOrSignature?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
