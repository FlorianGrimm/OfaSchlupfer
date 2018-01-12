using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FailoverModeReplicaOption : AvailabilityReplicaOption {
        private FailoverModeOptionKind _value;

        public FailoverModeOptionKind Value {
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
