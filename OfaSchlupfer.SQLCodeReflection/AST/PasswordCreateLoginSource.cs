namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class PasswordCreateLoginSource : CreateLoginSource {
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

        public bool Hashed { get; set; }

        public bool MustChange { get; set; }

        public List<PrincipalOption> Options { get; } = new List<PrincipalOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Password?.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
