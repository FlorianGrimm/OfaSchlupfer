using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ProviderEncryptionSource : EncryptionSource {
        private Identifier _name;

        private List<KeyOption> _keyOptions = new List<KeyOption>();

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<KeyOption> KeyOptions {
            get {
                return this._keyOptions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.KeyOptions.Count; i < count; i++) {
                this.KeyOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
