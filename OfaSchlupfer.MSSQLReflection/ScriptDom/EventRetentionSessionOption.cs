using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EventRetentionSessionOption : SessionOption {
        private EventSessionEventRetentionModeType _value;

        public EventSessionEventRetentionModeType Value {
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
