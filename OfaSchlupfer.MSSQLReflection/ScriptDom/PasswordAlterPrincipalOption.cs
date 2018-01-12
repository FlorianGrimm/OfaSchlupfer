namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PasswordAlterPrincipalOption : PrincipalOption {
        private Literal _password;

        private Literal _oldPassword;

        public Literal Password {
            get {
                return this._password;
            }
            set {
                base.UpdateTokenInfo(value);
                this._password = value;
            }
        }

        public Literal OldPassword {
            get {
                return this._oldPassword;
            }
            set {
                base.UpdateTokenInfo(value);
                this._oldPassword = value;
            }
        }

        public bool MustChange { get; set; }

        public bool Unlock { get; set; }

        public bool Hashed { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Password?.Accept(visitor);
            this.OldPassword?.Accept(visitor);
        }
    }
}
