namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateCryptographicProviderStatement : TSqlStatement {
        private Identifier _name;

        private Literal _file;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

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
            this.Name?.Accept(visitor);
            this.File?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
