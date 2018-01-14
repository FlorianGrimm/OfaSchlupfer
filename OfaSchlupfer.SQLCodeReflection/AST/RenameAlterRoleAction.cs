namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class RenameAlterRoleAction : AlterRoleAction {
        private Identifier _newName;

        public Identifier NewName {
            get {
                return this._newName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._newName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.NewName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
