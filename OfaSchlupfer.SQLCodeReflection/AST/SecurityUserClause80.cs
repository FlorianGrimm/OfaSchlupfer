using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SecurityUserClause80 : TSqlFragment {
        private List<Identifier> _users = new List<Identifier>();

        private UserType80 _userType80;

        public List<Identifier> Users {
            get {
                return this._users;
            }
        }

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
            for (int i = 0, count = this.Users.Count; i < count; i++) {
                this.Users[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
