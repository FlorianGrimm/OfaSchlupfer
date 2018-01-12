using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class UserStatement : TSqlStatement {
        private Identifier _name;

        private List<PrincipalOption> _userOptions = new List<PrincipalOption>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<PrincipalOption> UserOptions {
            get {
                return this._userOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.UserOptions.Count; i < count; i++) {
                this.UserOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
