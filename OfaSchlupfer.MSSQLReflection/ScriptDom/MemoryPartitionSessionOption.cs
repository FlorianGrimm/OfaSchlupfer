using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MemoryPartitionSessionOption : SessionOption {
        private EventSessionMemoryPartitionModeType _value;

        public EventSessionMemoryPartitionModeType Value {
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
