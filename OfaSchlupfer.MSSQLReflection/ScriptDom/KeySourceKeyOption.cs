using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class KeySourceKeyOption : KeyOption {
        private Literal _passPhrase;

        public Literal PassPhrase {
            get {
                return this._passPhrase;
            }
            set {
                base.UpdateTokenInfo(value);
                this._passPhrase = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PassPhrase?.Accept(visitor);
        }
    }
}
