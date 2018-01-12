using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UserLoginOption : TSqlFragment {
        private UserLoginOptionType _userLoginOptionType;

        private Identifier _identifier;

        public UserLoginOptionType UserLoginOptionType {
            get {
                return this._userLoginOptionType;
            }
            set {
                this._userLoginOptionType = value;
            }
        }

        public Identifier Identifier {
            get {
                return this._identifier;
            }
            set {
                base.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
