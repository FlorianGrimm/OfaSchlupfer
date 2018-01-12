using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class StateAuditOption : AuditOption {
        private OptionState _value;

        public OptionState Value {
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
