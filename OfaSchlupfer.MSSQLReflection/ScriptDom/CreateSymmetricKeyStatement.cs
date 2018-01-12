using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateSymmetricKeyStatement : SymmetricKeyStatement, IAuthorization {
        private List<KeyOption> _keyOptions = new List<KeyOption>();

        private Identifier _provider;

        private Identifier _owner;

        public List<KeyOption> KeyOptions {
            get {
                return this._keyOptions;
            }
        }

        public Identifier Provider {
            get {
                return this._provider;
            }

            set {
                this.UpdateTokenInfo(value);
                this._provider = value;
            }
        }

        public Identifier Owner {
            get {
                return this._owner;
            }

            set {
                this.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            for (int i=0, count = this.KeyOptions.Count; i < count; i++) {
                this.KeyOptions[i].Accept(visitor);
            }
            this.Provider?.Accept(visitor);
            int j = 0;
            for (int count2 = base.EncryptingMechanisms.Count; j < count2; j++) {
                base.EncryptingMechanisms[j].Accept(visitor);
            }
            this.Owner?.Accept(visitor);
        }
    }
}
