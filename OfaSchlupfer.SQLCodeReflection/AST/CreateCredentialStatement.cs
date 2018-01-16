namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateCredentialStatement : CredentialStatement {
        private Identifier _cryptographicProviderName;

        public Identifier CryptographicProviderName {
            get {
                return this._cryptographicProviderName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._cryptographicProviderName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CryptographicProviderName?.Accept(visitor);
        }
    }
}
