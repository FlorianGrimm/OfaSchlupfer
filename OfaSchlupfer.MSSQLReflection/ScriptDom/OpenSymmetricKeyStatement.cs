using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OpenSymmetricKeyStatement : TSqlStatement {
        private Identifier _name;

        private CryptoMechanism _decryptionMechanism;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public CryptoMechanism DecryptionMechanism {
            get {
                return this._decryptionMechanism;
            }

            set {
                this.UpdateTokenInfo(value);
                this._decryptionMechanism = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.DecryptionMechanism?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
