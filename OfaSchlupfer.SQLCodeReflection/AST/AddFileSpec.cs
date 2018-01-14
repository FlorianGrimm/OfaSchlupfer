namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AddFileSpec : TSqlFragment {
        private ScalarExpression _file;

        private Literal _fileName;

        public ScalarExpression File {
            get {
                return this._file;
            }

            set {
                this.UpdateTokenInfo(value);
                this._file = value;
            }
        }

        public Literal FileName {
            get {
                return this._fileName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.File?.Accept(visitor);
            this.FileName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
