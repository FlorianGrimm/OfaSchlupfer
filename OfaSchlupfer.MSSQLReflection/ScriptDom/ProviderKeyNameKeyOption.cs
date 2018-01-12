using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ProviderKeyNameKeyOption : KeyOption {
        private Literal _keyName;

        public Literal KeyName {
            get {
                return this._keyName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._keyName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.KeyName?.Accept(visitor);
        }
    }
}
