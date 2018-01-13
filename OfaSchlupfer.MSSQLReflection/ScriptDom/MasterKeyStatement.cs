namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class MasterKeyStatement : TSqlStatement {
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

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Password?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
