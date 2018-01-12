using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExternalTableDistributionOption : ExternalTableOption {
        private ExternalTableDistributionPolicy _value;

        public ExternalTableDistributionPolicy Value {
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
