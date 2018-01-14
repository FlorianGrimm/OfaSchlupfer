namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterLoginAddDropCredentialStatement : AlterLoginStatement {
        private Identifier _credentialName;

        public bool IsAdd { get; set; }

        public Identifier CredentialName {
            get {
                return this._credentialName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._credentialName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CredentialName?.Accept(visitor);
        }
    }
}
