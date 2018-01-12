using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UserRemoteServiceBindingOption : RemoteServiceBindingOption {
        private Identifier _user;

        public Identifier User {
            get {
                return this._user;
            }
            set {
                base.UpdateTokenInfo(value);
                this._user = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.User?.Accept(visitor);
        }
    }
}
