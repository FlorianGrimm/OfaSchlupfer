using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AuthenticationEndpointProtocolOption : EndpointProtocolOption {
        private AuthenticationTypes _authenticationTypes;

        public AuthenticationTypes AuthenticationTypes {
            get {
                return this._authenticationTypes;
            }
            set {
                this._authenticationTypes = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
