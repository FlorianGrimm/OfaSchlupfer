using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExternalTableRejectTypeOption : ExternalTableOption {
        private ExternalTableRejectType _value;

        public ExternalTableRejectType Value {
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
