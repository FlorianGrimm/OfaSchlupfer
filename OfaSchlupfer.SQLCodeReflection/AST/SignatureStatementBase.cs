using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class SignatureStatementBase : TSqlStatement {
        private SchemaObjectName _element;

        private List<CryptoMechanism> _cryptos = new List<CryptoMechanism>();

        public bool IsCounter { get; set; }

        public SignableElementKind ElementKind { get; set; }

        public SchemaObjectName Element {
            get {
                return this._element;
            }

            set {
                this.UpdateTokenInfo(value);
                this._element = value;
            }
        }

        public List<CryptoMechanism> Cryptos {
            get {
                return this._cryptos;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Element?.Accept(visitor);
            for (int i = 0, count = this.Cryptos.Count; i < count; i++) {
                this.Cryptos[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
