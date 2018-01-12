using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateUserStatement : UserStatement {
        private UserLoginOption _userLoginOption;

        public UserLoginOption UserLoginOption {
            get {
                return this._userLoginOption;
            }
            set {
                base.UpdateTokenInfo(value);
                this._userLoginOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            this.UserLoginOption?.Accept(visitor);
            for (int i=0, count = base.UserOptions.Count; i < count; i++) {
                base.UserOptions[i].Accept(visitor);
            }
        }
    }
}
