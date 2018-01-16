namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SecurityUserClause80 : TSqlFragment {
        private UserType80 _userType80;

        public List<Identifier> Users { get; } = new List<Identifier>();

        public UserType80 UserType80 {
            get {
                return this._userType80;
            }

            set {
                this._userType80 = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Users.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
