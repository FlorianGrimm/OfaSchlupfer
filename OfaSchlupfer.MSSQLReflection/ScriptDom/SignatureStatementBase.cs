using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class SignatureStatementBase : TSqlStatement {
        private bool _isCounter;

        private SignableElementKind _elementKind;

        private SchemaObjectName _element;

        private List<CryptoMechanism> _cryptos = new List<CryptoMechanism>();

        public bool IsCounter {
            get {
                return this._isCounter;
            }
            set {
                this._isCounter = value;
            }
        }

        public SignableElementKind ElementKind {
            get {
                return this._elementKind;
            }
            set {
                this._elementKind = value;
            }
        }

        public SchemaObjectName Element {
            get {
                return this._element;
            }
            set {
                base.UpdateTokenInfo(value);
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
            for (int i=0, count = this.Cryptos.Count; i < count; i++) {
                this.Cryptos[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
