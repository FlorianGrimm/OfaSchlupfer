using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class CredentialStatement : TSqlStatement {
        private Identifier _name;

        private Literal _identity;

        private Literal _secret;

        private bool _isDatabaseScoped;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public Literal Identity {
            get {
                return this._identity;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identity = value;
            }
        }

        public Literal Secret {
            get {
                return this._secret;
            }

            set {
                this.UpdateTokenInfo(value);
                this._secret = value;
            }
        }

        public bool IsDatabaseScoped {
            get {
                return this._isDatabaseScoped;
            }

            set {
                this._isDatabaseScoped = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Identity?.Accept(visitor);
            this.Secret?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
