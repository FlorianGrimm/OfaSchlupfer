namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateCertificateStatement : CertificateStatementBase, IAuthorization {
        private EncryptionSource _certificateSource;

        private Identifier _owner;

        public EncryptionSource CertificateSource {
            get {
                return this._certificateSource;
            }

            set {
                this.UpdateTokenInfo(value);
                this._certificateSource = value;
            }
        }

        public List<CertificateOption> CertificateOptions { get; } = new List<CertificateOption>();

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
            this.CertificateSource?.Accept(visitor);
            this.PrivateKeyPath?.Accept(visitor);
            this.CertificateOptions.Accept(visitor);
            this.EncryptionPassword?.Accept(visitor);
            this.DecryptionPassword?.Accept(visitor);
            this.Owner?.Accept(visitor);
        }
    }
}
