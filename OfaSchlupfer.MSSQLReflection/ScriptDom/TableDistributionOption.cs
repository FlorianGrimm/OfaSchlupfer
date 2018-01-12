using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableDistributionOption : TableOption {
        private TableDistributionPolicy _value;

        public TableDistributionPolicy Value {
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
