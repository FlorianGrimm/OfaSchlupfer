using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CertificateCreateLoginSource : CreateLoginSource {
        private Identifier _certificate;

        private Identifier _credential;

        public Identifier Certificate {
            get {
                return this._certificate;
            }
            set {
                base.UpdateTokenInfo(value);
                this._certificate = value;
            }
        }

        public Identifier Credential {
            get {
                return this._credential;
            }
            set {
                base.UpdateTokenInfo(value);
                this._credential = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Certificate?.Accept(visitor);
            this.Credential?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
