namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class OpenMasterKeyStatement : TSqlStatement {
        private Literal _password;

        public Literal Password {
            get {
                return this._password;
            }

            set {
                this.UpdateTokenInfo(value);
                this._password = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Password?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
