namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateLoginStatement : TSqlStatement {
        private Identifier _name;

        private CreateLoginSource _source;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public CreateLoginSource Source {
            get {
                return this._source;
            }

            set {
                this.UpdateTokenInfo(value);
                this._source = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Name != null) {
                this.Name.Accept(visitor);
            }
            if (this.Source != null) {
                this.Source.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
