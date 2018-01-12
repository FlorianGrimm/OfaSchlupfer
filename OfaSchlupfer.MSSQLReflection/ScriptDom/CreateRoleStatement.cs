namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class CreateRoleStatement : RoleStatement, IAuthorization {
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
            base.AcceptChildren(visitor);
            this.Owner?.Accept(visitor);
        }
    }
}
