namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateUserStatement : UserStatement {
        private UserLoginOption _userLoginOption;

        public UserLoginOption UserLoginOption {
            get {
                return this._userLoginOption;
            }

            set {
                this.UpdateTokenInfo(value);
                this._userLoginOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.UserLoginOption?.Accept(visitor);
            this.UserOptions.Accept(visitor);
        }
    }
}
