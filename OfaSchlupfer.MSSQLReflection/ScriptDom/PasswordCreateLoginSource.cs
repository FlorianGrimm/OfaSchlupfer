using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PasswordCreateLoginSource : CreateLoginSource {
        private Literal _password;

        private bool _hashed;

        private bool _mustChange;

        private List<PrincipalOption> _options = new List<PrincipalOption>();

        public Literal Password {
            get {
                return this._password;
            }

            set {
                this.UpdateTokenInfo(value);
                this._password = value;
            }
        }

        public bool Hashed {
            get {
                return this._hashed;
            }

            set {
                this._hashed = value;
            }
        }

        public bool MustChange {
            get {
                return this._mustChange;
            }

            set {
                this._mustChange = value;
            }
        }

        public List<PrincipalOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Password?.Accept(visitor);
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
