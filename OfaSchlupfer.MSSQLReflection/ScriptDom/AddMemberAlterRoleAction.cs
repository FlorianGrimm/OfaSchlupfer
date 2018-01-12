namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AddMemberAlterRoleAction : AlterRoleAction {
        private Identifier _member;

        public Identifier Member {
            get {
                return this._member;
            }
            set {
                base.UpdateTokenInfo(value);
                this._member = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Member?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
