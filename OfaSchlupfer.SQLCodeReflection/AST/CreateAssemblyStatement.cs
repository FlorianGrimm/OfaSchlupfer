namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateAssemblyStatement : AssemblyStatement, IAuthorization {
        private Identifier _owner;

        public Identifier Owner {
            get {
                return this._owner;
            }

            set {
                this.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.Options.Accept(visitor);
            this.Owner?.Accept(visitor);
        }
    }
}
