using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AsymmetricKeyCreateLoginSource : CreateLoginSource {
        private Identifier _key;

        private Identifier _credential;

        public Identifier Key {
            get {
                return this._key;
            }
            set {
                base.UpdateTokenInfo(value);
                this._key = value;
            }
        }

        public Identifier Credential {
            get {
                return this._credential;
            }
            set {
                base.UpdateTokenInfo(value);
                this._credential = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Key?.Accept(visitor);
            this.Credential?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
