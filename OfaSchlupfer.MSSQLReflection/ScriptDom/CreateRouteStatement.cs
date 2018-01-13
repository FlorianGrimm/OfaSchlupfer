namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateRouteStatement : RouteStatement, IAuthorization {
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
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            int i = 0;
            for (int count = base.RouteOptions.Count; i < count; i++) {
                base.RouteOptions[i].Accept(visitor);
            }
            if (this.Owner != null) {
                this.Owner.Accept(visitor);
            }
        }
    }
}
