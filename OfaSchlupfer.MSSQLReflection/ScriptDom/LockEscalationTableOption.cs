using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LockEscalationTableOption : TableOption {
        private LockEscalationMethod _value;

        public LockEscalationMethod Value {
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
