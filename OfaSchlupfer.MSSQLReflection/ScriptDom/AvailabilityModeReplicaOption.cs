using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AvailabilityModeReplicaOption : AvailabilityReplicaOption {
        private AvailabilityModeOptionKind _value;

        public AvailabilityModeOptionKind Value {
            get {
                return this._value;
            }
            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
