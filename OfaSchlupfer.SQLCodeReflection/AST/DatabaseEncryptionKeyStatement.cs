namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class DatabaseEncryptionKeyStatement : TSqlStatement {
        private CryptoMechanism _encryptor;

        private DatabaseEncryptionKeyAlgorithm _algorithm;

        public CryptoMechanism Encryptor {
            get {
                return this._encryptor;
            }

            set {
                this.UpdateTokenInfo(value);
                this._encryptor = value;
            }
        }

        public DatabaseEncryptionKeyAlgorithm Algorithm {
            get {
                return this._algorithm;
            }

            set {
                this._algorithm = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Encryptor?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
