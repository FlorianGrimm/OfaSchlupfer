namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropMemberAlterRoleAction : AlterRoleAction {
        private Identifier _member;

        public Identifier Member {
            get {
                return this._member;
            }

            set {
                this.UpdateTokenInfo(value);
                this._member = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Member != null) {
                this.Member.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
