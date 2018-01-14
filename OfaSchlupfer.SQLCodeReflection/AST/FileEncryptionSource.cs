namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class FileEncryptionSource : EncryptionSource {
        private Literal _file;

        public bool IsExecutable { get; set; }

        public Literal File {
            get {
                return this._file;
            }

            set {
                this.UpdateTokenInfo(value);
                this._file = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.File?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
