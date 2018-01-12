namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateAsymmetricKeyStatement : TSqlStatement, IAuthorization {
        private Identifier _name;

        private EncryptionSource _keySource;

        private EncryptionAlgorithm _encryptionAlgorithm;

        private Literal _password;

        private Identifier _owner;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public EncryptionSource KeySource {
            get {
                return this._keySource;
            }
            set {
                base.UpdateTokenInfo(value);
                this._keySource = value;
            }
        }

        public EncryptionAlgorithm EncryptionAlgorithm {
            get {
                return this._encryptionAlgorithm;
            }
            set {
                this._encryptionAlgorithm = value;
            }
        }

        public Literal Password {
            get {
                return this._password;
            }
            set {
                base.UpdateTokenInfo(value);
                this._password = value;
            }
        }

        public Identifier Owner {
            get {
                return this._owner;
            }
            set {
                base.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.KeySource?.Accept(visitor);
            this.Password?.Accept(visitor);
            this.Owner?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
