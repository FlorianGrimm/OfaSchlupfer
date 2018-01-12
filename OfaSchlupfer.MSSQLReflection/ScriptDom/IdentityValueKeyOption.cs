using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IdentityValueKeyOption : KeyOption {
        private Literal _identityPhrase;

        public Literal IdentityPhrase {
            get {
                return this._identityPhrase;
            }
            set {
                base.UpdateTokenInfo(value);
                this._identityPhrase = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.IdentityPhrase?.Accept(visitor);
        }
    }
}
