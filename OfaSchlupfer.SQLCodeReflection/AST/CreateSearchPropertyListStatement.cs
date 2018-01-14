namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateSearchPropertyListStatement : TSqlStatement, IAuthorization {
        private Identifier _name;

        private MultiPartIdentifier _sourceSearchPropertyList;

        private Identifier _owner;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public MultiPartIdentifier SourceSearchPropertyList {
            get {
                return this._sourceSearchPropertyList;
            }
            set {
                this.UpdateTokenInfo(value);
                this._sourceSearchPropertyList = value;
            }
        }

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
            if (this.Name != null) {
                this.Name.Accept(visitor);
            }
            if (this.SourceSearchPropertyList != null) {
                this.SourceSearchPropertyList.Accept(visitor);
            }
            if (this.Owner != null) {
                this.Owner.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
