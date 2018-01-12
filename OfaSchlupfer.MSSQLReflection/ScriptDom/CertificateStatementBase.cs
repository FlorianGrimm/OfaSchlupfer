using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class CertificateStatementBase : TSqlStatement, IPasswordChangeOption {
        private Identifier _name;

        private OptionState _activeForBeginDialog;

        private Literal _privateKeyPath;

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

        public OptionState ActiveForBeginDialog {
            get {
                return this._activeForBeginDialog;
            }

            set {
                this._activeForBeginDialog = value;
            }
        }

        public Literal PrivateKeyPath {
            get {
                return this._privateKeyPath;
            }

            set {
                this.UpdateTokenInfo(value);
                this._privateKeyPath = value;
            }
        }

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

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.PrivateKeyPath?.Accept(visitor);
            this.EncryptionPassword?.Accept(visitor);
            this.DecryptionPassword?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
