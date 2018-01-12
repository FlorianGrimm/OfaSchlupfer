using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ChangeTrackingFullTextIndexOption : FullTextIndexOption {
        private ChangeTrackingOption _value;

        public ChangeTrackingOption Value {
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
