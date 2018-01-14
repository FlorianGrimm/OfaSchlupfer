using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateCertificateStatement : CertificateStatementBase, IAuthorization {
        private EncryptionSource _certificateSource;

        private List<CertificateOption> _certificateOptions = new List<CertificateOption>();

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

        public List<CertificateOption> CertificateOptions {
            get {
                return this._certificateOptions;
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
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            this.CertificateSource?.Accept(visitor);
            if (base.PrivateKeyPath != null) {
                base.PrivateKeyPath.Accept(visitor);
            }
            for (int i=0, count = this.CertificateOptions.Count; i < count; i++) {
                this.CertificateOptions[i].Accept(visitor);
            }
            if (base.EncryptionPassword != null) {
                base.EncryptionPassword.Accept(visitor);
            }
            if (base.DecryptionPassword != null) {
                base.DecryptionPassword.Accept(visitor);
            }
            this.Owner?.Accept(visitor);
        }
    }
}
