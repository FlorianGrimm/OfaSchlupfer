namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterCryptographicProviderStatement : TSqlStatement {
        private Identifier _name;

        private EnableDisableOptionType _option;

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

        public EnableDisableOptionType Option {
            get {
                return this._option;
            }

            set {
                this._option = value;
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
