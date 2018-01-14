namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class RestoreMasterKeyStatement : BackupRestoreMasterKeyStatementBase {
        private Literal _encryptionPassword;

        public bool IsForce { get; set; }

        public Literal EncryptionPassword {
            get {
                return this._encryptionPassword;
            }

            set {
                this.UpdateTokenInfo(value);
                this._encryptionPassword = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.EncryptionPassword?.Accept(visitor);
        }
    }
}
