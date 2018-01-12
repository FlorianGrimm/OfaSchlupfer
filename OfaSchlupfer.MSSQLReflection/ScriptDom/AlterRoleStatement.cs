namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class AlterRoleStatement : RoleStatement {
        private AlterRoleAction _action;

        public AlterRoleAction Action {
            get {
                return this._action;
            }

            set {
                this.UpdateTokenInfo(value);
                this._action = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Action?.Accept(visitor);
        }
    }
}
