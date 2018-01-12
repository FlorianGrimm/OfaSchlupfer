using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RolePayloadOption : PayloadOption {
        private DatabaseMirroringEndpointRole _role;

        public DatabaseMirroringEndpointRole Role {
            get {
                return this._role;
            }
            set {
                this._role = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
