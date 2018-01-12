using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SecondaryRoleReplicaOption : AvailabilityReplicaOption {
        private AllowConnectionsOptionKind _allowConnections;

        public AllowConnectionsOptionKind AllowConnections {
            get {
                return this._allowConnections;
            }
            set {
                this._allowConnections = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
