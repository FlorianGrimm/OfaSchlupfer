using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AuthenticationPayloadOption : PayloadOption {
        private AuthenticationProtocol _protocol;

        private Identifier _certificate;

        private bool _tryCertificateFirst;

        public AuthenticationProtocol Protocol {
            get {
                return this._protocol;
            }
            set {
                this._protocol = value;
            }
        }

        public Identifier Certificate {
            get {
                return this._certificate;
            }
            set {
                base.UpdateTokenInfo(value);
                this._certificate = value;
            }
        }

        public bool TryCertificateFirst {
            get {
                return this._tryCertificateFirst;
            }
            set {
                this._tryCertificateFirst = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Certificate?.Accept(visitor);
        }
    }
}
