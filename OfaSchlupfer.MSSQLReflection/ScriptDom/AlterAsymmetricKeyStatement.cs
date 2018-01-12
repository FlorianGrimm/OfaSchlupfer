namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterAsymmetricKeyStatement : TSqlStatement, IPasswordChangeOption {
        private Identifier _name;

        private Literal _attestedBy;

        private Literal _encryptionPassword;

        private Literal _decryptionPassword;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public Literal AttestedBy {
            get {
                return this._attestedBy;
            }

            set {
                this.UpdateTokenInfo(value);
                this._attestedBy = value;
            }
        }

        public AlterCertificateStatementKind Kind { get; set; }

        public Literal EncryptionPassword {
            get {
                return this._encryptionPassword;
            }

            set {
                this.UpdateTokenInfo(value);
                this._encryptionPassword = value;
            }
        }

        public Literal DecryptionPassword {
            get {
                return this._decryptionPassword;
            }

            set {
                this.UpdateTokenInfo(value);
                this._decryptionPassword = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.AttestedBy?.Accept(visitor);
            this.EncryptionPassword?.Accept(visitor);
            this.DecryptionPassword?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
